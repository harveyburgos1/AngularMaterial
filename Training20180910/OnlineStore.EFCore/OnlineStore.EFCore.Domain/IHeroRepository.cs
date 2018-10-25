using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IHeroRepository:IRepository<Hero>
    {
        PaginationResult<Hero> RetrieveHeroesWithPagination(int page, int itemsPerPage, string filter);
    }
}
