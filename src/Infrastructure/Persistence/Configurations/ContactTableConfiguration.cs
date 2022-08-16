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

            builder.Property(contact => contact.Id).ValueGeneratedOnAdd();

            builder.Property(contact => contact.CreationDatetime).ValueGeneratedOnAdd();
        }
    }

}