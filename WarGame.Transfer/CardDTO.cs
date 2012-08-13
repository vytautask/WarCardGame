using System.Xml.Serialization;

namespace WarGame.Transfer
{
	public class CardDTO : TransferObjectBase
	{
		private SymbolsDTO _symbol = SymbolsDTO.CLUBS;
		private byte _number = 0;

		public CardDTO()
		{

		}

		public CardDTO(SymbolsDTO symbol, byte number)
		{
			Symbol = symbol;
			Number = number;
		}

		[XmlAttributeAttribute("symbol")]
		public SymbolsDTO Symbol
		{
			get { return _symbol; }
			set { _symbol = value; }
		}

		[XmlAttributeAttribute("number")]
		public byte Number
		{
			get { return _number; }
			set { _number = value; }
		}
	}
}
