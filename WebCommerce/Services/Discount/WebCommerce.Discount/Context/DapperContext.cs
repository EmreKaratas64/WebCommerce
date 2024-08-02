using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebCommerce.Discount.Entites;

namespace WebCommerce.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NKLMS7G\\MSSQLSERVER01;initial Catalog=WebCommerceDiscountDb;integrated Security=true");
        }

        public DbSet<Coupon> Coupons;
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);


    }
}
