using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WarGame.Transfer;

namespace WarGameService
{
	[ServiceContract]
	public interface IWarGameService
	{
		[OperationContract]
		ActiveCardDTO GetActiveCardForUser(long userID);

		[OperationContract]
		byte GetCardsLeft(long userID);
	}
}
