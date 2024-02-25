using Microsoft.EntityFrameworkCore;
using Products_Web.Data.Entities;

namespace Products_Web.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}
