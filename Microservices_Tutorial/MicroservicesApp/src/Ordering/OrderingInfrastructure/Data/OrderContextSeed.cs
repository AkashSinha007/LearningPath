using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingInfrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                orderContext.Database.Migrate();
                //orderContext.Database.EnsureCreated();

                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(exception.Message);
                    //System.Threading.Thread.Sleep(2000);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order() { UserName = "swn", FirstName = "Akash", LastName = "Sinha", EmailAddress = "Akash@gmail.com",AddressLine = "India_state",Country="India" }
            };
        }
    }
}
