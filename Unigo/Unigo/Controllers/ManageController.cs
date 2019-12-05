using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Unigo.Data;
using Unigo.Models;
using Unigo.Repo;

namespace Unigo.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IRepository<Person> peopleRepo;
        private IRepository<Car> carRepo;
        private IRepository<Ride> rideRepo;


        public ManageController()
        {
        }

        public ManageController(IRepository<Person> pr, IRepository<Car> cr, IRepository<Ride> rr)
        {
            this.peopleRepo = pr;
            this.carRepo = cr;
            this.rideRepo = rr;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage = ResolveMessage(message);
                
            return View(FillIndexViewWithData());
        }

        // Custom created methods
        //----------------------

        // POST: /Manage/UpdatePersonData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePersonData(UpdatePersonViewModel model)
        {
            ManageMessageId? message = ManageMessageId.NoChange;

            if (!ModelState.IsValid)
            {
                return View("Index", FillIndexViewWithData(updatePerson: model));
            }

            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();

            userPerson.FirstName = model.FirstName;
            userPerson.LastName = model.LastName;
            userPerson.Email = model.Email;
            userPerson.DateOfBirth = model.DateOfBirth;
            userPerson.PhoneNumber= model.PhoneNumber;

            // get user object from the storage
            var user = UserManager.FindById(userId);
            user.Email = model.Email;
            UserManager.Update(user);

            peopleRepo.SaveChanges();
            message = ManageMessageId.ChangeSuccess;

            return RedirectToAction("Index", new { Message = message });

        }

        // POST: /Manage/AddCar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCar(AddCarViewModel model)
        {
            ManageMessageId? message = ManageMessageId.NoChange;

            if (!ModelState.IsValid)
            {
                return View("Index", FillIndexViewWithData(addCar: model));
            }

            var userId = User.Identity.GetUserId();
            int userPersonId = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault().Id;

            Car car = new Car
            {
                Brand = model.Brand,
                Color = model.Color,
                LicensePlate = model.LicensePlate,
                NumberOfSeats = model.NumberOfSeats,
                RiderId = userPersonId,
                Type = model.Type
            };

            if (!String.IsNullOrEmpty(model.Description))
            {
                car.Description = model.Description;
            }

            this.carRepo.Add(car);
            this.carRepo.SaveChanges();

            message = ManageMessageId.AddCarSuccess;

            return RedirectToAction("Index", new { Message = message });

        }

        // GET: /Manage/CreateRide
        public ActionResult CreateRide(ManageMessageId? message)
        {
            ManageMessageId? messageIndex = ManageMessageId.CarNeeded;

            string identityUserId = User.Identity.GetUserId();
            int userId = peopleRepo.GetAll().Where(m => m.UserId == identityUserId).FirstOrDefault().Id;

            //var cars = carRepo.GetAll().Where(m => m.RiderId == userId);
            //Car activeCar = cars.Where(m => m.Status == ActiveInactive.Active).FirstOrDefault();

            ViewBag.StatusMessage = ResolveMessage(message);

            //if (activeCar == null)
            //{
            //    return RedirectToAction("Index", new { Message = messageIndex });
            //}

            return View();

        }

        // POST: /Manage/CreateRide
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRide(CreateRideViewModel model)
        {
            ManageMessageId? message = ManageMessageId.RideCreated;
            int userId = peopleRepo.GetAll().Where(m=> m.UserId == User.Identity.GetUserId()).FirstOrDefault().Id;

            var cars = carRepo.GetAll().Where(m => m.RiderId == userId);
            Car activeCar = cars.Where(m => m.Status == ActiveInactive.Active).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.NumberOfSeats > activeCar.NumberOfSeats)
            {
                message = ManageMessageId.MoreSeats;
                RedirectToAction("CreateRide", new { Message = message });
            }

            Ride newRide = new Ride
            {
                RiderId = userId,
                DestinationId = model.DestinationId,
                Status = ActiveInactive.Active,
                LeavingTime = model.LeavingTime,
                NumberOfSeats = model.NumberOfSeats,
                CarId = activeCar.Id,
                Price = "Negotiate with driver.",
                StartPoint = model.StartPoint,
                StartLat = model.StartLat,
                StartLong = model.StartLong
            };

            rideRepo.Add(newRide);
            rideRepo.SaveChanges();

            return RedirectToAction("Index", new { Message = message });

        }

        // Custom methods end


        // Auto-Generated methods under
        //------------------------------

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber


        //
        // POST: /Manage/AddPhoneNumber

        //
        // POST: /Manage/RemovePhoneNumber
        
        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", FillIndexViewWithData(changePass:model));
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return RedirectToAction("Index", new { Message = ManageMessageId.NoChange });
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return View("Error");
            }

            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where
                (auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();

            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePhoneSuccess,
            ChangeFirstLastNameSuccess,
            ChangePasswordSuccess,
            ChangeSuccess,
            CarNeeded,
            MoreSeats,
            AddCarSuccess,
            Error,
            NoChange,
            RideCreated,
            RemovePhoneSuccess,
            RemoveLoginSuccess
        }

        private string ResolveMessage(ManageMessageId? message)
        {
            return message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.ChangePhoneSuccess ? "Your phone number was changed."
                : message == ManageMessageId.ChangeSuccess ? "Changed succesfully."
                : message == ManageMessageId.RemoveLoginSuccess ? "Removed login success."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : message == ManageMessageId.ChangeFirstLastNameSuccess ? "Your first and last name has been changed."
                : message == ManageMessageId.NoChange ? "No changes has been made."
                : message == ManageMessageId.AddCarSuccess ? "Car added successfully."
                : message == ManageMessageId.RideCreated ? "Ride created successfully."
                : message == ManageMessageId.CarNeeded ? "You need to add a car to Create ride."
                : message == ManageMessageId.MoreSeats ? "Cannot create ride withmore seats than in car."
                : ""; ;
        }

        private IndexViewModel FillIndexViewWithData(
            UpdatePersonViewModel updatePerson = null, 
            ChangePasswordViewModel changePass = null,
            AddCarViewModel addCar = null)
        {
            // Person update view model creation
            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();
            UpdatePersonViewModel personView = new UpdatePersonViewModel
            {
                FirstName = userPerson.FirstName,
                LastName = userPerson.LastName,
                PhoneNumber = userPerson.PhoneNumber,
                Email = userPerson.Email,
                DateOfBirth = userPerson.DateOfBirth
            };

            // Change pass view model creation
            ChangePasswordViewModel changePassword = new ChangePasswordViewModel();

            // Add car vies model creation
            AddCarViewModel addCarModel = new AddCarViewModel();
            addCarModel.carList = this.carRepo.GetAll().Where(c => c.RiderId == userPerson.Id).ToList();

            // Check for specific parameters
            if (updatePerson != null)
            {
                personView = updatePerson;
            }

            if(changePass != null)
            {
                changePassword = changePass;
            }

            if(addCar != null)
            {
                addCarModel = addCar;
            }


            var model = new IndexViewModel
            {
                PersonData = personView,
                ChangePass = changePassword,
                AddCar = addCarModel
            };

            return model;
        }

#endregion
    }
}