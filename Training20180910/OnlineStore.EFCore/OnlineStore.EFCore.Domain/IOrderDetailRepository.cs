using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IOrderDetailRepository: IRepository<OrderDetail>
    {
        OrderDetail GetOrderDetailsWithForeignKey(Guid id);

    }
}
