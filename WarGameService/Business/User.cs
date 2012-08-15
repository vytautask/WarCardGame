using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGameService.Business
{
	public class User : BusinessObjectBase
	{
		private long _id = -1;
		private string _username = null;
		private string _password = null;
		private string _firstname = null;
		private string _lastname = null;
		private ulong _gamesCount = 0;
		private ulong _gamesWon = 0;
        private UserDeck _deck = null;

		public User()
		{

		}

		public User(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public long Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public string Firstname
		{
			get { return _firstname; }
			set { _firstname = value; }
		}

		public string Lastname
		{
			get { return _lastname; }
			set { _lastname = value; }
		}

		public ulong GamesCount
		{
			get { return _gamesCount; }
			set { _gamesCount = value; }
		}

		public ulong GamesWon
		{
			get { return _gamesWon; }
			set { _gamesWon = value; }
		}

        public UserDeck Deck
        {
            get { return _deck; }
            set { _deck = value; }
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

                    if (_deck != null)
                    {
                        _deck.Dispose();
                        _deck = null;
                    }
				}
			}

			base.Dispose(disposing);
		}
	}
}