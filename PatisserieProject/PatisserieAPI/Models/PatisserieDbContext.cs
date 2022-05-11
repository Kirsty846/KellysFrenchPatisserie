using Microsoft.EntityFrameworkCore;

namespace PatisserieAPI.Model
{
    public class PatisserieDbContext : DbContext 
    {
        public PatisserieDbContext()
        {
        }

        public PatisserieDbContext(DbContextOptions<PatisserieDbContext> options) :base(options)
        { 
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
