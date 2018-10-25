using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IItemRepository : IRepository<Item>
    {
        PaginationResult<Item> RetrieveItemWithPagination(int page, int itemsPerPage, string filter);
    }
}
