using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class HeroRepository: RepositoryBase<Hero>,IHeroRepository
    {
        public HeroRepository(OnlineStoreDbContext context):base(context)
        {

        }

        public PaginationResult<Hero> RetrieveHeroesWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Hero> result = new PaginationResult<Hero>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Hero>().OrderBy(x => x.Name).Skip(page).Take(itemsPerPage).ToList();
                if(result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Hero>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Hero>().Where(x => x.Name.ToLower().Contains(filter.ToLower())).OrderBy(x => x.Name)
             .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Hero>().Where(x => x.Name.ToLower().Contains(filter.ToLower())).Count();
                }
            }

            return result;
        }
    }
}
