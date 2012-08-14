using System.Collections.Generic;

namespace WarGameService.Business
{
	internal class UserDeck : Deck
	{
		private User _user = null;

		public UserDeck(User user, IList<Card> cards)
		{
			User = user;
			Cards = cards;
		}

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}
	}
}