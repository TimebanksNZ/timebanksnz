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
using TimebanksNZ.Models;
using TimebanksNZ.DAL.Entities;
using System.Collections.Generic;
using System.Web.Security;
using MySql.Web.Security;

namespace TimebanksNZ.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private User _userManager;

        public AccountController()
        {
        }

        private IEnumerable<SelectListItem> GetBanks()
        {
            var tb = new TimebanksNZ.DAL.MySqlDb.Repositories.TimebankRepository();
            var roles = tb.GetAll()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.IdTimebank.ToString(),
                                    Text = x.Name
                                });

            return new SelectList(roles, "Value", "Text");
        }


        //
        // GET: /Account/Login
        [HttpGet]
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
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = Membership.ValidateUser(model.Email, model.Password);

            if (result)
                return RedirectToLocal(returnUrl);
            else
                return View(model);
                
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}
        }

        ////
        //// GET: /Account/VerifyCode
        //[AllowAnonymous]
        //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        //{
        //    // Require that the user has already logged in via username/password or external login
        //    if (!await SignInManager.HasBeenVerifiedAsync())
        //    {
        //        return View("Error");
        //    }
        //    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var tb = new TimebanksNZ.DAL.MySqlDb.Repositories.TimebankRepository();
            var banks = tb.GetAll();
            var model = new RegisterViewModel
            {
                bank = GetBanks(),
                IsAddressPublic = true,
                IsEmailPublic = true,
                IsPhonePublic = true
            };
            return View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model, string timeBank)
        {
            if (ModelState.IsValid)
            {
                var currUser = new User();
                currUser.FirstName = model.FirstName;
                currUser.LastName = model.LastName;
                currUser.EmailAddress = model.Email;
                currUser.MobilePhone = model.MobilePhone;
                currUser.WorkPhone = model.WorkPhone;
                currUser.HomePhone = model.HomePhone;
                currUser.StreetAddress1 = model.Address1;
                currUser.StreetAddress2 = model.Address2;
                currUser.City = model.City;
                currUser.Suburb = model.Suburb;
                currUser.Postcode = model.PostalCode;
                currUser.Community = model.Community;                
                currUser.IsPhonePublic = model.IsPhonePublic;
                currUser.IsAddressPublic = model.IsAddressPublic;
                currUser.IsEmailPublic = model.IsEmailPublic;
                currUser.AcceptedTerms = model.AcceptedTerms;
                currUser.Created = DateTime.Now;
                currUser.GeoLat = model.GeoLat;
                currUser.GeoLong = model.GeoLong;
                currUser.IdTimebank = int.Parse(model.SelectedBank);

                DI.CurrentRepositoryFactory.CreateUserRepository().Insert(currUser);

                var user = Membership.CreateUser(model.Email, model.Password, model.Email);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = new {Succeeded = true};
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        ////
        //// POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserAppManager.FindByNameAsync(model.Email);
        //        if (user == null || !(await UserAppManager.IsEmailConfirmedAsync(user.Id)))
        //        {
        //            // Don't reveal that the user does not exist or is not confirmed
        //            return View("ForgotPasswordConfirmation");
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        // Send an email with this link
        //        // string code = await UserManager.GeneratePasswordResetTokenAsync(user.IdMember);
        //        // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.IdMember, code = code }, protocol: Request.Url.Scheme);		
        //        // await UserManager.SendEmailAsync(user.IdMember, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //        // return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        ////
        //// POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var user = await UserAppManager.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    var result = await UserAppManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    AddErrors(result);
        //    return View();
        //}

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

 

        [HttpGet]
        public ActionResult UnapprovedUsers()
        {
            var userRepo = DI.CurrentRepositoryFactory.CreateUserRepository();
            var unapprovedUsers = userRepo.GetAll().Where(u => !u.Approved);
            
            return View(unapprovedUsers);
        }

        [HttpPost]
        public ActionResult ApproveUsers(IEnumerable<User> users)
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
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