using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ItemRepository:RepositoryBase<Item>,IItemRepository
    {
        public ItemRepository(OnlineStoreDbContext context):base(context)
        {

        }

        public PaginationResult<Item> RetrieveItemWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Item> result = new PaginationResult<Item>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Item>().OrderBy(x => x.Name).Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Item>().Count();
                }

            }
            else
            {
                result.Results = context.Set<Item>().Where(x => x.Name.ToLower().Contains(filter.ToLower())).OrderBy(x => x.Name)
                    .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Item>().Where(x => x.Name.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}
