using Microsoft.EntityFrameworkCore;
using OrderingCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingInfrastructure.Data
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
