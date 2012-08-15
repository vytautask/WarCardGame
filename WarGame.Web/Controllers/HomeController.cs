using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarGame.Transfer;
using WarGame.Web.Models;

namespace WarGame.Web.Controllers
{
	public class HomeController : Controller
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

		[Authorize]
		public ActionResult Index()
		{
			ViewBag.CardsLeft = UserModel.GetCardsLeft();

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		[Authorize]
		public ActionResult DrawCard()
		{
			ViewBag.ActiveCards = UserModel.DrawCard();
			ViewBag.CardsLeft = UserModel.GetCardsLeft();

			return View();
		}
	}
}
