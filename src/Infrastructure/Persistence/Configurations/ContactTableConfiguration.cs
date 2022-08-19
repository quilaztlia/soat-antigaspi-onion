using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class ContactTableConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact), "antigaspi");

            builder.HasKey(contact => contact.Id);

            builder.Property(contact => contact.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(contact => contact.FirstName)
                .HasColumnType("nvarchar(150)");

            builder.Property(contact => contact.LastName)
                .HasColumnType("nvarchar(150)");

            builder.Property(contact => contact.Email)
                    .HasColumnType("nvarchar(150)");

            builder.Property(contact => contact.Phone)
                    .HasColumnType("nvarchar(20)");

            builder.Property(contact => contact.Message)
                    .HasColumnType("nvarchar(300)");

            builder.Property(contact => contact.CreationDatetime)
                .HasColumnType("datetime2")
                .ValueGeneratedOnAdd();

            //TODO: Relation 1 contact Many Offers !!
            //public Guid OfferId { get; set; } =>
            //builder.Property(contact => contact);        
        }
    }

}