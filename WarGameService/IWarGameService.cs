using System.ServiceModel;
using WarGame.Transfer;

namespace WarGameService
{
	[ServiceContract]
	public interface IWarGameService
	{
		[OperationContract]
		ActiveCardDTO GetActiveCard();

		[OperationContract]
		byte GetCardsLeft();

		[OperationContract]
		void RegisterUser(string username, string password, string firstname, string lastname);
	}
}
