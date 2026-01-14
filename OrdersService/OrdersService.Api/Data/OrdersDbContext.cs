using Microsoft.EntityFrameworkCore;
using OrdersService.Api.Models;

namespace OrdersService.Api.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();
    }
}
