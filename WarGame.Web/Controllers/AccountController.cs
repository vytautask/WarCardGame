using System.Web.Mvc;
using System.Web.Security;
using WarGame.Web.Models;
using WarGame.Web.ViewModels;

namespace WarGame.Web.Controllers
{
	public class AccountController : Controller
	{
		private UserModel _userModel = null;

		public UserModel UserModel
		{
			get
			{
				if(_userModel == null)
					_userModel = new UserModel();

				return _userModel;
			}
			set { _userModel = value; }
		}

		//
		// GET: /Account/LogOn

		public ActionResult LogOn()
		{
			return View();
		}

		//
		// POST: /Account/LogOn

		[HttpPost]
		public ActionResult LogOn(LogOnViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				Session["username"] = model.UserName;
				Session["password"] = model.Password;

				if (UserModel.IsUsernameAndPasswordCorrect())//Membership.ValidateUser(model.UserName, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/LogOff

		public ActionResult LogOff()
		{
			Session["username"] = null;
			Session["password"] = null;
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/Register

		public ActionResult Register()
		{
			return View();
		}

		//
		// POST: /Account/Register

		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				Session["username"] = "sync";
				Session["password"] = "sync";

				string result = UserModel.RegisterUser(model.UserName, model.Password, model.FirstName, model.LastName);

				Session["username"] = model.UserName;
				Session["password"] = model.Password;

				if (string.IsNullOrEmpty(result))
				{
					FormsAuthentication.SetAuthCookie(model.UserName, false);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Error while registering user");
				}
			}

			return View(model);
		}
	}
}
