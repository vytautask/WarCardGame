using WarGame.Transfer;

namespace WarGameService.Business
{
	public class CardToDTOTransformer
	{
		public static CardDTO GetCardDTO(Card card)
		{
			CardDTO dto = new CardDTO()
			              	{
									Number = card.Number,
									Symbol = (SymbolsDTO)((int)card.Symbol)
			              	};

			return dto;
		}

	}
}