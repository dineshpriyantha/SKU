using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SKU.Model
{
    public interface IDatabaseContext
    {
        DbSet<Cabinet> Cabinets { get; set; }
        DbSet<Sku> Skus { get; set; }
        Task<int> SaveChangesAsync();
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Sku> Skus { get; set; }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
