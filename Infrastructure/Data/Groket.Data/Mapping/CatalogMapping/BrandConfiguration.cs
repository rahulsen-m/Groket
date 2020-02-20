﻿using Groket.Domain.Models.CatalogModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Groket.Data.Mapping.CatalogMapping
{
    /// <summary>
    /// Set the configuration of the Brand entity
    /// </summary>
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id).HasName("BrandId");

            builder.Property(b => b.CreatedBy)
                .IsRequired();

            builder.Property(b => b.Created)                
                .HasDefaultValueSql("GetDate()")
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Slug)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.IsPublished)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasOne(b => b.Media)
                .WithOne(b => b.Brand);

            builder.HasMany(b => b.Products)
                .WithOne(b => b.Brand);

        }
    }
}