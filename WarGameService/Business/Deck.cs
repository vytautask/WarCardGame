using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace WarGameService.Business
{
	internal class Deck : BusinessObjectBase
	{
		private IList<Card> _cards = null;

		public Deck()
		{

		}

		public IList<Card> Cards
		{
			get
			{
				if (_cards == null)
					_cards = GetFullCardDeck();

				return _cards;
			}
			set { _cards = value; }
		}

		public IList<Card> GetFullCardDeck()
		{
			List<Card> cards = new List<Card>(52);

			string[] symbolNames = Enum.GetNames(typeof (Symbols));

			foreach (string symbolName in symbolNames)
			{
				for (byte i = 1; i <= 13; i++)
				{
					cards.Add(new Card((Symbols)Enum.Parse(typeof (Symbols), symbolName), i));
				}
			}

			return cards;
		}

		public Nullable<bool> IsCardGreater(Card card1, Card card2)
		{
			Nullable<bool> result = null;

			if (card1 != null)
			{
				if (card2 != null)
				{
					if (card1.Number > card2.Number)
					{
						result = true;
					}
					else if (card1.Number < card2.Number)
					{
						result = false;
					}
				}
				else
				{
					throw new ArgumentNullException("Second Card parameter (card2) is null");
				}
			}
			else
			{
				throw new ArgumentNullException("First Card parameter (card1) is null");
			}

			return result;
		}

		public IList<Card> GetRandomSetOfCards()
		{
			List<Card> cards = new List<Card>();
			Random random = new Random();

			bool foundEnough = false;

			while (!foundEnough)
			{
				Card randomCard = Cards[random.Next(52)];

				if (!cards.Contains(randomCard))
				{
					cards.Add(randomCard);
					randomCard = null;
				}

				if (cards.Count == 26)
					foundEnough = true;
			}

			return cards;
		}

		public override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_cards != null)
				{
					for (int i = 0; i < _cards.Count; i++)
					{
						_cards[i].Dispose();
					}

					_cards.Clear();
					_cards = null;
				}

				base.Dispose(disposing);
			}
		}
	}
}