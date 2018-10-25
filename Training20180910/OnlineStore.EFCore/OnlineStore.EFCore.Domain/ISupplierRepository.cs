using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        PaginationResult<Supplier> RetrieveSupplierWithPagination(int page, int itemsPerPage, string filter);

    }
}
