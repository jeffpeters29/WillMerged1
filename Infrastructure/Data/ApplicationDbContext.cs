using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }

        public DbSet<Will> Wills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Will>(ConfigureWill);
            builder.Entity<Customer>(ConfigureCustomer);
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<Child>(ConfigureChild);
        }

        private void ConfigureWill(EntityTypeBuilder<Will> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Customer)
                   .WithOne(c => c.Will);

            builder.HasMany(w => w.Children)
                   .WithOne(c => c.Will);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                   .IsRequired(true)
                   .HasMaxLength(50);
              
            builder.Property(c => c.DateOfBirth)
                   .IsRequired(true);

            //builder.Property(w => w.Email)
            //   .IsRequired(true);

            builder.HasOne(c => c.Address)
                   .WithOne(a => a.Customer)
                   .HasForeignKey<Customer>(c => c.AddressId)
                   .IsRequired(true);
        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Postcode)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(a => a.Number)
               .IsRequired(true)
               .HasMaxLength(100);

            builder.Property(a => a.Village)
               .IsRequired(true)
               .HasMaxLength(100);

            builder.Property(a => a.City)
               .IsRequired(true)
               .HasMaxLength(100);
        }

        private void ConfigureChild(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
