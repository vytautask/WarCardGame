using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using WarGameService.Business.Managers;
using WarGameService.Business;

namespace WarGameService
{
	public class CustomValidator : UserNamePasswordValidator
	{
		private UserManager _userManager = null;

		public UserManager UserManager
		{
			get { 
				if (_userManager == null)
					_userManager = new UserManager();

				return _userManager;
			}
			set { _userManager = value; }
		}

		public override void Validate(string username, string password)
		{
			User user = UserManager.GetUser(username, password);

			if (user != null || (username == "sync" && password == "sync")) //sync user is used for new user creation only
				return;

			throw new SecurityTokenException("Unknown Username or Password");
		}
	}
}