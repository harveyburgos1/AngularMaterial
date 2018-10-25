using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ShipperRepository:RepositoryBase<Shipper>,IShipperRepository
    {
        public ShipperRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Shipper> RetrieveShipperWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Shipper> result = new PaginationResult<Shipper>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Shipper>().OrderBy(x => x.CompanyName)
                    .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = result.Results.Count;
                }
            }
            else
            {
                result.Results = context.Set<Shipper>().Where(x => x.CompanyName.ToLower()
                .Contains(filter.ToLower())).OrderBy(x => x.CompanyName).Skip(page).Take(itemsPerPage).ToList();
            }
            return result;
        }
    }
}
