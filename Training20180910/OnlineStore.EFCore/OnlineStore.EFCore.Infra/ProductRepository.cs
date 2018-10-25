using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext context):base(context)
        {
            
        }
        public PaginationResult<Product> RetrieveProductWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Product> result = new PaginationResult<Product>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Product>().OrderBy(x => x.ProductName)
             .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Product>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Product>().Where(x => x.ProductName.ToLower().Contains(filter.ToLower())).OrderBy(x => x.ProductName)
             .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Product>().Where(x => x.ProductName.ToLower().Contains(filter.ToLower())).Count();
                }
            }

            return result;
        }
    }
}
