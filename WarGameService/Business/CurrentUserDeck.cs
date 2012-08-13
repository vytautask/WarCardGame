using System.Collections.Generic;

namespace WarGameService.Business
{
	internal class CurrentUserDeck : Deck
	{
		private long _userId = -1;

		public CurrentUserDeck(long userId, IList<Card> cards)
		{
			UserId = userId;
			Cards = cards;
		}

		public long UserId
		{
			get { return _userId; }
			set { _userId = value; }
		}
	}
}