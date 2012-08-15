using System;
using WarGame.Web.WarGameServiceReference;
using WarGame.Transfer;

namespace WarGame.Web.Models
{
	public class UserModel
	{
		public byte GetCardsLeft()
		{
			using (WarGameServiceClient client = ServiceClientFactory.CreateWarGameServiceClient())
			{
				return client.GetCardsLeft();
			}
		}

		public bool IsUsernameAndPasswordCorrect()
		{
			bool result = false;

			try
			{
				using (WarGameServiceClient client = ServiceClientFactory.CreateWarGameServiceClient())
				{
					client.GetCardsLeft();
					result = true;
				}
			}
			catch (Exception)
			{
			}

			return result;
		}

		public string RegisterUser(string username, string password, string firstname, string lastname)
		{
			string result = null;

			try
			{
				using (WarGameServiceClient client = ServiceClientFactory.CreateWarGameServiceClient())
				{
					try
					{
						client.RegisterUser(username, password, firstname, lastname);
					}
					catch (Exception ex)
					{
						result = ex.ToString();
					}
				}
			}
			catch (Exception ex)
			{
			}

			return result;
		}

		public ActiveCardDTO DrawCard()
		{
			using (WarGameServiceClient client = ServiceClientFactory.CreateWarGameServiceClient())
			{
				return client.GetActiveCard();
			}
		}
	}
}