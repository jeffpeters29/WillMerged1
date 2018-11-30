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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Will>(ConfigureWill);
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<Child>(ConfigureChild);
        }

        private void ConfigureWill(EntityTypeBuilder<Will> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.FullName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(w => w.DOB)
                .IsRequired(true);

            builder.Property(w => w.Email)
               .IsRequired(true);

            builder.HasOne(w => w.Address)
                   .WithOne(a => a.Will)
                   .HasForeignKey<Will>(w => w.AddressId)
                   .IsRequired(false);

            builder.HasMany(w => w.Children)
                   .WithOne(c => c.Will);
        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(a => a.Postcode)
                .IsRequired(true)
                .HasMaxLength(50);
        }

        private void ConfigureChild(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(w => w.Id);
        }
    }
}
