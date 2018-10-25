using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class OrderDetailRepository:RepositoryBase<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(OnlineStoreDbContext context):base(context)
        {

        }

        public OrderDetail GetOrderDetailsWithForeignKey(Guid id)
        {
            OrderDetail result = new OrderDetail();
            result = context.Set<OrderDetail>().Where(x => x.OrderID == id).FirstOrDefault();
            return result;
        }
    }
}
