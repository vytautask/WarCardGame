using FluentNHibernate.Mapping;

namespace WarGameService.Business.Mappings
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Id(x => x.Id);
			Map(x => x.Username).Unique();
			Map(x => x.Password);
			Map(x => x.Firstname);
			Map(x => x.Lastname);
			Map(x => x.GamesCount);
			Map(x => x.GamesWon);
			HasMany<Card>(x => x.DeckCards) //definatelly not the best way
				.Cascade.All()
				.Not.LazyLoad();
		}
	}
}