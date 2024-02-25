using Microsoft.EntityFrameworkCore;
using Products.Data.Model;

namespace Products.Data
{
    public class ProductContext : DbContext
    {
        private readonly string connectionString = "Server=localhost;Database=Products;Uid=codeUser;Pwd=codeUserPass123";

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
