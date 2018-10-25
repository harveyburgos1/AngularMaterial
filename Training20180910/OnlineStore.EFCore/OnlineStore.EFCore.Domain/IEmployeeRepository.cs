using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.EFCore.Domain
{
    public interface IEmployeeRepository
        : IRepository<Employee>
    {
        PaginationResult<Employee> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter);

    }
}
