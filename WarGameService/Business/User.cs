using System.Collections.Generic;

namespace WarGameService.Business
{
	public class User : BusinessObjectBase
	{
		private long _id = -1;
		private string _username = null;
		private string _password = null;
		private string _firstname = null;
		private string _lastname = null;
		private long _gamesCount = 0;
		private long _gamesWon = 0;
		private IList<Card> _deckCards = null;

		public User()
		{
		}

		public User(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public virtual long Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public virtual string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		public virtual string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public virtual string Firstname
		{
			get { return _firstname; }
			set { _firstname = value; }
		}

		public virtual string Lastname
		{
			get { return _lastname; }
			set { _lastname = value; }
		}

		public virtual long GamesCount
		{
			get { return _gamesCount; }
			set { _gamesCount = value; }
		}

		public virtual long GamesWon
		{
			get { return _gamesWon; }
			set { _gamesWon = value; }
		}

		public virtual IList<Card> DeckCards
		{
			get { return _deckCards; }
			set { _deckCards = value; }
		}

		public override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!IsDisposed)
				{
					_username = null;
					_password = null;
					_firstname = null;
					_lastname = null;

					if (_deckCards != null)
					{
						for (int i = 0; i < _deckCards.Count; i++)
						{
							_deckCards[i].Dispose();
						}

						_deckCards.Clear();
						_deckCards = null;
					}
				}
			}

			base.Dispose(disposing);
		}
	}
}