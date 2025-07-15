using Microsoft.EntityFrameworkCore;
using TrackWise.Models.Entities;


namespace TrackWise.Database
{
    public class TrackWiseDbContext:DbContext
    {
        public TrackWiseDbContext(DbContextOptions<TrackWiseDbContext> options) : base(options) { }


        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Asset>()
                .Property(a => a.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Asset>()
                .Property(a => a.IdentifierType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
