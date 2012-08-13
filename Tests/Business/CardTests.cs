using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WarGameService.Business;

namespace Tests.Business
{
	[TestFixture]
	public class CardTests : TestBase
	{
		
		[Test]
		public void CreateObjectWithPropertiesSet_ObjectCreatedAndPropertiesSet()
		{
			Card card = new Card();
			Assert.AreEqual(0, card.Number);
			Assert.AreEqual(Symbols.CLUBS, card.Symbol);

			card = new Card(Symbols.HEARTS, 12);
			Assert.AreEqual(12, card.Number);
			Assert.AreEqual(Symbols.HEARTS, card.Symbol);
		}
	}
}
