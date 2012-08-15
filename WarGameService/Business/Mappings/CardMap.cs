using FluentNHibernate.Mapping;

namespace WarGameService.Business.Mappings
{
	public class CardMap : ClassMap<Card>
	{
		public CardMap()
		{
			Id(x => x.Id);
			Map(x => x.Symbol);
			Map(x => x.Number);
		}
	}
}