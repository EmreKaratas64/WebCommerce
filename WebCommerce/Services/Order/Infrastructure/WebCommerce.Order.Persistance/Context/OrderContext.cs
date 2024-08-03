using Microsoft.EntityFrameworkCore;
using WebCommerce.Order.Domain.Entities;

namespace WebCommerce.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NKLMS7G\\MSSQLSERVER01;initial Catalog=WebCommerceOrderDb;integrated Security=true");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
