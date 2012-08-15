using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGameService.Business
{
	public class Card: BusinessObjectBase
	{
		private Symbols _symbol = Symbols.CLUBS;
		private byte _number = 0;

		public Card()
		{

		}

		public Card(Symbols symbol, byte number)
		{
			Symbol = symbol;
			Number = number;
		}

		public Symbols Symbol
		{
			get { return _symbol; }
			set { _symbol = value; }
		}

		public byte Number
		{
			get { return _number; }
			set { _number = value; }
		}
	}
}