using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CategoryName).IsRequired();
        }
    }
}

