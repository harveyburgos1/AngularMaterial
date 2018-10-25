using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineStore.EFCore.Infra
{
    public class EmployeeRepository
        : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnlineStoreDbContext context)
            : base(context)
        {

        }

        public PaginationResult<Employee> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Employee> result = new PaginationResult<Employee>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Employee>().OrderBy(x => x.FirstName)
                    .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = result.Results.Count;
                }
            }
            else
            {
                result.Results = context.Set<Employee>().Where(x => x.FirstName.ToLower()
                .Contains(filter.ToLower())).OrderBy(x => x.FirstName).Skip(page).Take(itemsPerPage).ToList();
            }
            return result;
        }
    }
}
