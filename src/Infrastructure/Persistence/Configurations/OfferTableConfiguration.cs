using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    //TODO: Delete MagicString: Check EnumTypes SQL !
    //      Relationship contact, offers, status, 
    internal sealed class OfferTableConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable(nameof(Offer), "antigaspi");

            builder.HasKey(offer => offer.Id);

            builder.Property(offer => offer.Id)
                .ValueGeneratedOnAdd();

            builder.Property(offer => offer.Title)
                .HasColumnType("nvarchar(300)")
                .IsRequired(true);       

builder.Property(offer => offer.CompanyName)
                  .HasColumnType("nvarchar(300)")
                .IsRequired(true);

            builder.Property(offer => offer.Description)
                   .HasColumnType("nvarchar(300)")
                .IsRequired(true);
        

        builder.Property(offer => offer.Email)
                   .HasColumnType("nvarchar(300)")
                .IsRequired(true);

        builder.Property(offer => offer.Address)
                   .HasColumnType("nvarchar(300)")
                .IsRequired(true);

        //TODO: StatusTable => Constraints??
        builder.Property(offer => offer.Status)
                   .HasColumnType("integer")
                .IsRequired(true);

        //CHECK: without Required => FALSE
        builder.Property(offer => offer.Availability)
                   .HasColumnType("datetime2");        

        builder.Property(offer => offer.Expiration)
                .HasColumnType("datetime2");        
    }
}

}