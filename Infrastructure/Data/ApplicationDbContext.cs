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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<FuneralType> FuneralTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

        public DbSet<Will> Wills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Partner> Partners { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<FuneralType>(ConfigureFuneralType);
            builder.Entity<Will>(ConfigureWill);
            builder.Entity<Customer>(ConfigureCustomer);
            builder.Entity<Partner>(ConfigurePartner);
            builder.Entity<Child>(ConfigureChild);
            builder.Entity<LegalGuardian>(ConfigureLegalGuardian);
            builder.Entity<Executor>(ConfigureExecutor);
            builder.Entity<Trustee>(ConfigureTrustee);
            builder.Entity<CashRecipient>(ConfigureCashRecipient);
            builder.Entity<GiftRecipient>(ConfigureGiftRecipient);
            builder.Entity<ResidueRecipient>(ConfigureResidueRecipient);

        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Postcode).IsRequired(true).HasMaxLength(50);

            builder.Property(a => a.Number).IsRequired(true).HasMaxLength(100);

            builder.Property(a => a.Village).IsRequired(true).HasMaxLength(100);

            builder.Property(a => a.City).IsRequired(true).HasMaxLength(100);
        }

        private void ConfigureFuneralType(EntityTypeBuilder<FuneralType> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Description).IsRequired(true).HasMaxLength(50);
        }

        private void ConfigureWill(EntityTypeBuilder<Will> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.UserId).IsRequired(true);

            builder.Property(w => w.WillStatus).IsRequired(true);

            builder.HasOne(w => w.Customer).WithOne(c => c.Will).IsRequired();
            builder.HasOne(w => w.Partner).WithOne(c => c.Will);
            builder.HasMany(w => w.Children).WithOne(c => c.Will);
            builder.HasMany(w => w.Executors).WithOne(c => c.Will);

            builder.Property(w => w.FuneralType).IsRequired(false);
            builder.Property(w => w.FuneralWishes).IsRequired(false);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(c => c.DateOfBirth).IsRequired(true);

            builder.HasOne(c => c.Address)
                   .WithOne(a => a.Customer)
                   .HasForeignKey<Customer>(c => c.AddressId)
                   .IsRequired(true);
        }

        private void ConfigurePartner(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(p => p.DateOfBirth).IsRequired(true);

            builder.HasOne(p => p.Address)
                  .WithOne(a => a.Partner)
                  .HasForeignKey<Partner>(c => c.AddressId)
                  .IsRequired(true);
        }

        private void ConfigureChild(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName).IsRequired(true).HasMaxLength(50);

            builder.Property(c => c.DateOfBirth).IsRequired(true);

            builder.Property(c => c.IsAddressSame).IsRequired(true);

            builder.HasOne(c => c.Address)
                   .WithOne(a => a.Child)
                   .HasForeignKey<Child>(c => c.AddressId)
                   .IsRequired(true);

            builder.HasOne(c => c.LegalGuardian)
                  .WithOne(l => l.Child)
                  .HasForeignKey<Child>(c => c.LegalGuardianId)
                  .IsRequired(false);
        }

        private void ConfigureLegalGuardian(EntityTypeBuilder<LegalGuardian> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.FullName).IsRequired(true).HasMaxLength(100);

            builder.HasOne(l => l.Address)
                   .WithOne(a => a.LegalGuardian)
                   .HasForeignKey<LegalGuardian>(l => l.AddressId)
                   .IsRequired(true);

            builder.HasOne(l => l.Relationship)
                   .WithOne(a => a.LegalGuardian)
                   .HasForeignKey<LegalGuardian>(l => l.RelationshipId)
                   .IsRequired(true);

        }

        private void ConfigureExecutor(EntityTypeBuilder<Executor> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(e => e.Email).IsRequired(true);

            builder.Property(e => e.IsAwareFinances).IsRequired(true);

            builder.HasOne(e => e.Address)
                   .WithOne(a => a.Executor)
                   .HasForeignKey<Executor>(e => e.AddressId)
                   .IsRequired(true);

            builder.HasOne(e => e.Relationship)
                   .WithOne(a => a.Executor)
                   .HasForeignKey<Executor>(e => e.RelationshipId)
                   .IsRequired(true);
        }

        private void ConfigureTrustee(EntityTypeBuilder<Trustee> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName).IsRequired(true).HasMaxLength(100);

            builder.HasOne(t => t.Address)
                  .WithOne(a => a.Trustee)
                  .HasForeignKey<Trustee>(t => t.AddressId)
                  .IsRequired(true);

            builder.HasOne(t => t.Relationship)
                   .WithOne(a => a.Trustee)
                   .HasForeignKey<Trustee>(t => t.RelationshipId)
                   .IsRequired(true);
        }

        private void ConfigureCashRecipient(EntityTypeBuilder<CashRecipient> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(c => c.Amount).IsRequired();

            builder.HasOne(c => c.Address)
                  .WithOne(a => a.CashRecipient)
                  .HasForeignKey<CashRecipient>(c => c.AddressId)
                  .IsRequired(true);

            builder.HasOne(c => c.Relationship)
                   .WithOne(a => a.CashRecipient)
                   .HasForeignKey<CashRecipient>(c => c.RelationshipId)
                   .IsRequired(true);
        }

        private void ConfigureGiftRecipient(EntityTypeBuilder<GiftRecipient> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(g => g.Description).IsRequired().HasMaxLength(250);

            builder.HasOne(g => g.Address)
                   .WithOne(a => a.GiftRecipient)
                   .HasForeignKey<GiftRecipient>(g => g.AddressId)
                   .IsRequired(true);

            builder.HasOne(g => g.Relationship)
                   .WithOne(a => a.GiftRecipient)
                   .HasForeignKey<GiftRecipient>(g => g.RelationshipId)
                   .IsRequired(true);
        }

        private void ConfigureResidueRecipient(EntityTypeBuilder<ResidueRecipient> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(r => r.Level).IsRequired();

            builder.Property(r => r.Percentage).IsRequired();

            builder.HasOne(r => r.Address)
                   .WithOne(a => a.ResidueRecipient)
                   .HasForeignKey<ResidueRecipient>(r => r.AddressId)
                   .IsRequired(true);

            builder.HasOne(r => r.Relationship)
                   .WithOne(a => a.ResidueRecipient)
                   .HasForeignKey<ResidueRecipient>(r => r.RelationshipId)
                   .IsRequired(true);
        }

        private void ConfigureWitness(EntityTypeBuilder<Witness> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.FullName).IsRequired(true).HasMaxLength(100);

            builder.Property(w => w.Occupation).IsRequired();

            builder.HasOne(w => w.Address)
                  .WithOne(a => a.Witness)
                  .HasForeignKey<Witness>(w => w.AddressId)
                  .IsRequired(true);
        }
    }
}
