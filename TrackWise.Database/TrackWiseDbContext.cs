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

            modelBuilder.Entity<Currency>().HasData(
                 new Currency
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "US Dollar",
                    Code = "USD",
                    Symbol = '$'
                },
                new Currency
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Euro",
                    Code = "EUR",
                    Symbol = '€'
                },
                new Currency
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "British Pound",
                    Code = "GBP",
                    Symbol = '£'
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
