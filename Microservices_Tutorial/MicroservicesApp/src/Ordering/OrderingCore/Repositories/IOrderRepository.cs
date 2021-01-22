using OrderingCore.Entities;
using OrderingCore.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingCore.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
