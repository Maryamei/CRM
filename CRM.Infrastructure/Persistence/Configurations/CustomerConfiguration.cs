using CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(250);  
            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
