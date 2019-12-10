﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
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
        private IRepository<Destination> destRepo;


        public ManageController()
        {
        }

        public ManageController(IRepository<Person> pr, IRepository<Car> cr, IRepository<Ride> rr, IRepository<Destination> dr)
        {
            this.peopleRepo = pr;
            this.carRepo = cr;
            this.rideRepo = rr;
            this.destRepo = dr;
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

            var cars = carRepo.GetAll().Where(m => m.RiderId == userPersonId);
            Car activeCar = cars.Where(m => m.Status == 1).FirstOrDefault();

            // Defaultly set to zero
            int status = 0;
            if(activeCar == null)
            {
                status = 1;
            }

            Car car = new Car
            {
                Brand = model.Brand,
                Color = model.Color,
                LicensePlate = model.LicensePlate,
                NumberOfSeats = model.NumberOfSeats,
                RiderId = userPersonId,
                Type = model.Type,
                Status = status
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
            // Resolve error messages
            ManageMessageId? messageIndex = ManageMessageId.ActiveCarNeeded;
            ViewBag.StatusMessage = ResolveMessage(message);


            // Get active user
            string identityUserId = User.Identity.GetUserId();
            int userId = peopleRepo.GetAll().Where(m => m.UserId == identityUserId).FirstOrDefault().Id;
            // Get user's active car
            var cars = carRepo.GetAll().Where(m => m.RiderId == userId);
            Car activeCar = cars.Where(m => m.Status == 1).FirstOrDefault();

            if(activeCar == null)
            {
                return RedirectToAction("Index", new { Message = messageIndex });
            }


            CreateRideViewModel crvm = new CreateRideViewModel
            {
                Destinations = GetListOfDestination(),
                ActiveCar = activeCar
            };

            ViewBag.StatusMessage = ResolveMessage(message);

            return View(crvm);

        }



        private List<ListHelper> GetListOfDestination()
        {
            IEnumerable<Destination> dests = destRepo.GetAll().ToList();
            var selectList = new List<ListHelper>();

            foreach (var dest in dests)
            {
                var newItem = new ListHelper
                {
                    Id = dest.Id,
                    Name = dest.Name

                };
                selectList.Add(newItem);

            }

            return selectList;
        }

        // Geolocation get lat and lng -- switched for somethin better
        //private string GetLatLng(string address)
        //{
        //    address = "Wi, Aalborg";
        //    string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", 
        //        Uri.EscapeDataString(address), "AIzaSyBs3lGeDQjJj8VQ_c0KjZkQnlADlOXR0jU");

        //    WebRequest request = WebRequest.Create(requestUri);
        //    WebResponse response = request.GetResponse();
        //    XDocument xdoc = XDocument.Load(response.GetResponseStream());

        //    XElement result = xdoc.Element("GeocodeResponse").Element("result");
        //    XElement locationElement = result.Element("geometry").Element("location");
        //    var lat = locationElement.Element("lat").Value;
        //    var lng = locationElement.Element("lng").Value;

        //    string latlng = lat + " , " + lng;

        //    return latlng;
        //}

        // POST: /Manage/CreateRide
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRide(CreateRideViewModel model)
        {
            ManageMessageId? message = ManageMessageId.RideCreated;
            string identityUserId = User.Identity.GetUserId();
            int userId = peopleRepo.GetAll().Where(m=> m.UserId == identityUserId).FirstOrDefault().Id;

            var cars = carRepo.GetAll().Where(m => m.RiderId == userId);
            Car activeCar = cars.Where(m => m.Status == 1).FirstOrDefault();

            model.Destinations = GetListOfDestination();
            model.ActiveCar = activeCar;

            if (!Regex.Match(Request["datetimefield"], @"^([0]\d|[1][0-2])\/([0-2]\d|[3][0-1])\/([2][01]|[1][6-9])\d{2}(\s([0-1]\d|[2][0-3])(\:[0-5]\d){1,2})?$").Success)
            {
                ModelState.AddModelError("Leaqving Time", "Enter correct date format.");
                return View(model);
            }

            DateTime myDate = DateTime.ParseExact(Request["datetimefield"], "MM/dd/yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);


            if (!ModelState.IsValid)
            {
                return View(model);
            }         

            if (model.NumberOfSeats > model.ActiveCar.NumberOfSeats)
            {
                ModelState.AddModelError("NumberOfSeats", "Cannot obtain more people that seats in active car.");
                return View(model);
            }

            if (myDate.Ticks < DateTime.Now.AddMinutes(15).Ticks ) {
                ModelState.AddModelError("LeavingTime", "Cannot obtain more people that seats in active car.");
                return View(model);
            }

            Ride newRide = new Ride
            {
                RiderId = userId,
                DestinationId = model.DestinationId,
                Status = 1,
                LeavingTime = myDate,
                NumberOfSeats = model.NumberOfSeats,
                CarId = activeCar.Id,
                Price = "Negotiate with driver.",
                StartPoint = model.StartPoint,
                StartLatString = model.StartLat,
                StartLongString = model.StartLong 
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
            ActiveCarNeeded,
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
                : message == ManageMessageId.ActiveCarNeeded ? "You need have a active car to create ride."
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