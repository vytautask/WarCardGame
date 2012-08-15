using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WarGameService.Business;
using WarGameService.Business.Managers;

namespace Tests.Business.Managers
{
	[TestFixture]
	public class UserManagerTests : TestBase
	{
		private UserManager GetUserManager()
		{
			return new UserManager();	
		}

		[Test]
		public void SetUserDeck_SetsUserDeck_Success()
		{
			UserManager manager = GetUserManager();
			long userId = manager.AddUser(new User()
			                              	{
			                              		DeckCards = null,
			                              		Firstname = "jonas",
			                              		Lastname = "Jonaitis",
															GamesCount = 20,
															GamesWon = 25,
															Username = "jonasjon" + DateTime.Now.Ticks.ToString(),
															Password = "slapta"
			                              	});
			
			Assert.Greater(userId, 0);
			
			IList<Card> cards = new List<Card>();
			cards.Add(new Card(Symbols.DIAMONDS, 5));

			manager.SetUserDeck(userId, cards);

			User gotUser = manager.GetUser(userId);
			Assert.AreEqual(5, gotUser.DeckCards[0].Number);
			Assert.AreEqual(Symbols.DIAMONDS, gotUser.DeckCards[0].Symbol);
		}

	}
}
