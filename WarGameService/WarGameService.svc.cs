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
	public class WarGameService : IWarGameService
	{
		public ActiveCardDTO GetActiveCardForUser(long userID)
		{
			throw new NotImplementedException();
		}

		public byte GetCardsLeft(long userID)
		{
			throw new NotImplementedException();
		}
	}
}
