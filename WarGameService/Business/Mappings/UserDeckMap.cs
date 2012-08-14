using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WarGameService.Business.Mappings
{
    public class UserDeckMap : ClassMap<UserDeck>
    {
        public UserDeckMap()
        {
            HasOne<User>(x => x.User);
            HasMany<Card>(x => x.Cards);
        }
    }
}