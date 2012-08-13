using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace WarGameService
{
	public class CustomValidator : UserNamePasswordValidator
	{
		public override void Validate(string userName, string password)
		{
			if (userName == "test" && password == "test")
				return;
			throw new SecurityTokenException("Unknown Username or Password");
		}
	}
}