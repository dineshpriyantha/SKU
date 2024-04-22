using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SKU.Model
{
       public class DatabaseContext : DbContext
        {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Sku> Skus { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
