using System;
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


        public ManageController()
        {
        }

        public ManageController(IRepository<Person> pr)
        {
            this.peopleRepo = pr;
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
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.ChangePhoneSuccess ? "Your phone number was changed."
                : message == ManageMessageId.ChangeSuccess ? "Changed succesfully."
                : message == ManageMessageId.RemoveLoginSuccess ? "Removed login success."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : message == ManageMessageId.ChangeFirstLastNameSuccess ? "Your first and last name has been changed."
                : message == ManageMessageId.NoChange ? "No changes has been made."
                : "";

            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();

            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = userPerson.PhoneNumber,
                LastName = userPerson.LastName,
                FirstName = userPerson.FirstName,
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        // Custom created methods
        //----------------------

        // GET: /Manage/ChangeFirstLastName
        [HttpGet]
        public ActionResult ChangeFirstLastName()
        {
            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();

            return View(new ChangeFirstLastNameViewModel
            {
                NFirst = userPerson.FirstName,
                NLast = userPerson.LastName
            });
        }


        // POST: /Manage/ChangeFirstLastName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeFirstLastName(ChangeFirstLastNameViewModel model)
        {
            ManageMessageId? message = ManageMessageId.NoChange;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();

            if(userPerson.FirstName == model.NFirst && userPerson.LastName == model.NLast)
            {
                return RedirectToAction("Index", new { Message = message });
            }

            userPerson.FirstName = model.NFirst;
            userPerson.LastName = model.NLast;
            peopleRepo.SaveChanges();
            message = ManageMessageId.ChangeFirstLastNameSuccess;

            return RedirectToAction("Index", new { Message = message });

        }

        // POST: /Manage/ChangeFirstLastName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePersonData(RegisterViewModel model)
        {
            ManageMessageId? message = ManageMessageId.NoChange;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity.GetUserId();
            Person userPerson = peopleRepo.GetAll().Where(u => u.UserId == userId).FirstOrDefault();

            
            peopleRepo.SaveChanges();
            message = ManageMessageId.ChangeSuccess;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
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
            return View(model);
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
            Error,
            NoChange,
            RemovePhoneSuccess,
            RemoveLoginSuccess
        }

#endregion
    }
}