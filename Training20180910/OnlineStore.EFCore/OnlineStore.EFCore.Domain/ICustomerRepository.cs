using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface ICustomerRepository
        : IRepository<Customer>
    {
        PaginationResult<Customer> RetrieveCustomerWithPagination(int page, int itemsPerPage,string filter);
    }
}
