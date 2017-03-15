using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbLocalizationProvider.Queries
{
    public class GetAllResources
    {
        public class Query : IQuery<IEnumerable<LocalizationResource>> { }

        public class Handler : IQueryHandler<Query, IEnumerable<LocalizationResource>>
        {
            public IEnumerable<LocalizationResource> Execute(Query query)
            {
                using (var db = new LanguageEntities())
                {
                    return db.LocalizationResources.Include(r => r.Translations).ToList();
                }
            }
        }
    }
}
