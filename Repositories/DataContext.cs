using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    namespace Domain
    {
        public class DataContext : DbContext
        {
            public DbSet<DomainEntity> DomainEntitys { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=MyDatabase;Trusted_Connection=True;");
            }

            public static void Initialize(DataContext context)
            {
                // context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // context.Database.Migrate();

            }
        }
    }
}
