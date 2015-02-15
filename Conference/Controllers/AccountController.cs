using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Conference.Controllers
{
	public class AccountController : Controller
    {
		public ActionResult Login(String returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Login(LoginAccount account, String returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;

			if (!ModelState.IsValid) return View(account);

			try {
				if(Membership.ValidateUser(account.UserName, account.Password)) {
					FormsAuthentication.SetAuthCookie(account.UserName, account.Persist);
					return RedirectToDestination(returnUrl);
				} else {
					ModelState.AddModelError("LoginFailed", "Sorry, that username and password combination is not recognized.");
					return View(account);
				}
			} catch {
				ModelState.AddModelError("LoginFailed", "Sorry, we were unable to authenticate you.");
				return View(account);
			}
		}

		public ActionResult Register(String returnUrl = "")
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost()]
		public ActionResult Register(CreateAccount account, String returnUrl = "")
		{
			ViewBag.ReturnUrl = returnUrl;

			if (!ModelState.IsValid) return View(account);

			try {
				Membership.CreateUser(account.UserName, account.Password, account.Email);
				FormsAuthentication.SetAuthCookie(account.UserName, false);
				return RedirectToDestination(returnUrl);
			} catch {
				ModelState.AddModelError("AccountCreationFailed", "Sorry, we were unable to create your account.");
				return View(account);
			}			
		}

		private ActionResult RedirectToDestination(String returnUrl)
		{
			if(String.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

			if(!returnUrl.StartsWith("/")) returnUrl = "/" + returnUrl;

			if(Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
			else return RedirectToAction("Index", "Home");
		}
    }
}
