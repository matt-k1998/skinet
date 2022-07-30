using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // The IsRequired method means that the property cannot be null
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            // Each Product has a single ProductBrand.
            // The WithMany means that each brand can be associated with many Products.
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
                // The line above sets the foreign key, which was already done by EntityFramework,
                // But we can also be specific about the migration here.
             builder.HasOne(t => t .ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}