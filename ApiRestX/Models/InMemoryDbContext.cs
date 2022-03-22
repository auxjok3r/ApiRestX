using Microsoft.EntityFrameworkCore;
using ApiRestX.Models;

namespace ApiRestX.Models
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<ApiRestX.Models.Product> Product { get; set; }
    }
}
