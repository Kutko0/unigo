using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Unigo.Models;
using Unigo.Data;
using Unigo.Repo;
using System.Collections.Generic;

namespace Unigo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IRepository<Person> peopleRepo;
        private IRepository<Destination> destRepo;
        private IRepository<Ride> rideRepo;
        private IRepository<PersonRide> personRide;
        private IRepository<Car> carRepo;

        public AccountController()
        {
        }
        
        public AccountController(IRepository<Person> pr, IRepository<Destination> dr, 
            IRepository<Ride> ride, IRepository<PersonRide> personR, IRepository<Car> c)
        {
            this.peopleRepo = pr;
            this.destRepo = dr;
            this.rideRepo = ride;
            this.personRide = personR;
            this.carRepo = c;

        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
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
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:

                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {

            RegisterViewModel rvm = new RegisterViewModel
            {
                Campuses = GetListOfCampuses()
            };

            return View(rvm);
        }

        private List<ListHelper> GetListOfCampuses()
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

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserProfile", "Account");
            }

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    Person p = new Person
                    {
                        UserId = user.Id,
                        DateOfBirth = model.DateOfBirth,
                        PhoneNumber = model.PhoneNumber,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Joined = DateTime.Now,
                        Campus = model.CampusId,
                        City = model.City.ToString(),
                        Nationality = model.Nationality.ToString()
                    };

                    peopleRepo.Add(p);
                    peopleRepo.SaveChanges();

                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // Email code of we want to use it
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            model.Campuses = GetListOfCampuses();

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Profile
        [AllowAnonymous]
        public ActionResult UserProfile()
        {
            string userId = User.Identity.GetUserId();
            Person person = peopleRepo.GetAll().Where(m => m.UserId == userId).FirstOrDefault();
            

            UserProfileViewModel upvm = new UserProfileViewModel
            {
                Campus = destRepo.GetById(person.Campus).Name,
                Nationality = person.Nationality,
                City = person.City,
                FirstName = person.FirstName,
                Lastname = person.LastName,
                Joined = "Joined " + person.Joined.ToString("dd. MM. yyyy"),
                pastRides = GetPastFiveRides(person.Id),
                activeRides = GetActiveRidesAsDriver(person.Id),
                joinedActiveRides = GetActiveJoinedRides(person.Id),
                UrlPhoto = "https://i.kym-cdn.com/entries/icons/medium/000/029/043/Shaq_Tries_to_Not_Make_a_Face_While_Eating_Spicy_Wings___Hot_Ones_11-21_screenshot.png"
            };


            return View(upvm);
        }

        private List<InfoActiveJoinedRide> GetActiveJoinedRides(int id)
        {
            List<InfoActiveJoinedRide> ipr = new List<InfoActiveJoinedRide>();
            List<PersonRide> pRide = personRide.GetAll().Where(m => m.PersonId == id).ToList();

            foreach(var personR in pRide){
                Ride r = rideRepo.GetById(personR.RideId);
                Car c = carRepo.GetById(r.CarId);
                ipr.Add(new InfoActiveJoinedRide
                {
                    Destination = destRepo.GetById(r.DestinationId).Name,
                    Time = r.LeavingTime,
                    CarPlate = c.Brand + ", " + c.Type + "( " + c.LicensePlate + " )",
                    PersonRideId = personR.Id
                });
            }
           

            return ipr;
        }

        private List<InfoPastRide> GetPastFiveRides(int id)
        {
            List<InfoPastRide> ipr = new List<InfoPastRide>();
            List<PersonRide> rides = personRide.GetAll().Where(m => m.PersonId == id).Take(5).ToList();
            foreach(var x in rides)
            {
                Ride r = rideRepo.GetById(x.RideId);
                Person p = peopleRepo.GetById(r.RiderId);
                
                ipr.Add(new InfoPastRide
                {
                    Destination = destRepo.GetById(r.DestinationId).Name,
                    riderName = p.FirstName + " " + p.LastName,
                    Time = r.LeavingTime,
                    Id = r.Id
                });  
            }

            return ipr;
        }

        private List<InfoActiveRide> GetActiveRidesAsDriver(int id)
        {
            List<InfoActiveRide> ipr = new List<InfoActiveRide>();
            List<Ride> rides = rideRepo.GetAll().Where(m => m.RiderId == id).Where(m => m.Status == 1).ToList();
            foreach (var x in rides)
            {
                int peopleIn = personRide.GetAll().Where(m => m.RideId == x.Id).Count();

                ipr.Add(new InfoActiveRide
                {
                    Destination = destRepo.GetById(x.DestinationId).Name,
                    Time = x.LeavingTime,
                    NumberOfPeople = peopleIn,
                    RideId = x.Id
                });
            }

            return ipr;
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}