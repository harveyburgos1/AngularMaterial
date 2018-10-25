using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IShipperRepository:IRepository<Shipper>
    {
        PaginationResult<Shipper> RetrieveShipperWithPagination(int page, int itemsPerPage, string filter);

    }
}
