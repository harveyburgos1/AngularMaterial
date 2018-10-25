using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IProductRepository:IRepository<Product>
    {
        PaginationResult<Product> RetrieveProductWithPagination(int page, int itemsPerPage, string filter);
    }
}
