using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class OrderRepository:RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreDbContext context):base(context)
        {

        }
    }
}
