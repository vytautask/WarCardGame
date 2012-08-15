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
    //TODO: in future, all business logic should be implemented in separate commands, not there
	public class WarGameService : IWarGameService
	{
        static WarGameService()
        {

        }

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
