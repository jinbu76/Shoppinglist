using Microsoft.EntityFrameworkCore;
using Shoppinglist.Domains.Supermarket.Domain.Aggregate;

namespace Shoppinglist.Domains.Supermarket.Repository
{
    public class SupermarketDBContext : DbContext
    {
        public DbSet<SupermarketAggregate> Supermarkets { get; set; }
        public DbSet<AddressAggregate> Addresses { get; set; }

        public SupermarketDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupermarketAggregate>().ToTable("Supermarket");
            modelBuilder.Entity<SupermarketAggregate>().HasKey(s => s.Id);
            modelBuilder.Entity<SupermarketAggregate>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<SupermarketAggregate>().HasMany(s => s.Addresses).WithOne(s => s.Supermarket)
                .HasForeignKey(a => a.SupermarketId).HasPrincipalKey(s => s.Id);

            modelBuilder.Entity<AddressAggregate>().ToTable("Address");
            modelBuilder.Entity<AddressAggregate>().HasKey(a => a.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}