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

        public DbSet<Product> Products { get; set; }
        public DbSet<Flavour> Flavour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MiniTart>();

            builder.Entity<CelebrationCake>().HasOne(x => x.Flavour)
                .WithMany()
                .HasForeignKey(x => x.FlavourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Fudge>().HasOne(x => x.Flavour)
                .WithMany()
                .HasForeignKey(x => x.FlavourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Macaroon>().HasOne(x => x.Flavour)
                .WithMany()
                .HasForeignKey(x => x.FlavourId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
