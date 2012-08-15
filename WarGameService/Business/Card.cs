using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGameService.Business
{
	public class Card: BusinessObjectBase
	{
		private long _id = -1;
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

		public virtual long Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public virtual Symbols Symbol
		{
			get { return _symbol; }
			set { _symbol = value; }
		}

		public virtual byte Number
		{
			get { return _number; }
			set { _number = value; }
		}
	}
}