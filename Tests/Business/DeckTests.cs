using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WarGameService.Business;

namespace Tests.Business
{
	[TestFixture]
	public class DeckTests : TestBase
	{
		private Deck GetDeck()
		{
			return new Deck();
		}

		[Test]
		public void GetFullCardDeck_GetsAll52Cards_Got()
		{
			Deck deck = GetDeck();

			IList<Card> cards = deck.GetFullCardDeck();

			Assert.IsNotNull(cards);
			Assert.AreEqual(52, cards.Count);
			Assert.AreNotEqual(cards[0].Number, cards[1].Number);

			cards.Clear();
		}

		[Test]
		public void GetRandomSetOfCards_Gets26RandomNotRepeatedCards_Got()
		{
			Deck deck = GetDeck();

			IList<Card> cards = deck.GetRandomSetOfCards();

			Assert.IsNotNull(cards);

			HashSet<Card> cardSet = new HashSet<Card>(cards);

			Assert.AreEqual(26, cardSet.Count);

			cardSet.Clear();
			cards.Clear();
		}

		[Test]
		public void IsCardGreater_DeterminesIfGreaterCardCheckWorks_Works()
		{
			Deck deck = GetDeck();

			Card card1 = new Card(Symbols.DIAMONDS, 5);
			Card card2 = new Card(Symbols.HEARTS, 5);

			Assert.AreEqual(null, deck.IsCardGreater(card1, card2));

			card2.Number = 6;

			Assert.AreEqual(false, deck.IsCardGreater(card1, card2));

			card1.Number = 13;
			Assert.AreEqual(true, deck.IsCardGreater(card1, card2));
		}
	}
}
