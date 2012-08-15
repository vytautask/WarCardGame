using System.Net;
using System.Net.Security;
using System.Web;
using WarGame.Web.WarGameServiceReference;

namespace WarGame.Web.Models
{
	public class ServiceClientFactory
	{
		public static WarGameServiceClient CreateWarGameServiceClient()
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
         delegate { return true; });

			WarGameServiceClient client = new WarGameServiceClient();
			client.ClientCredentials.UserName.UserName = (string)HttpContext.Current.Session["username"]; //There should be dependency injection, not this stuff, because now it is not testable
			client.ClientCredentials.UserName.Password = (string)HttpContext.Current.Session["password"];

			return client;
		}
	}
}