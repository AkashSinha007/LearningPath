using Microsoft.EntityFrameworkCore;
using OrderingCore.Entities;
using OrderingCore.Repositories;
using OrderingInfrastructure.Data;
using OrderingInfrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingInfrastructure.Repositories
{
    public class OrderRepository : Repository<Order>,IOrderRepository
    {
        public OrderRepository(OrderContext dbContext):base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.UserName == userName).ToListAsync();

            return orderList;
        }
    }
}
