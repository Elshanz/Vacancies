using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class CurriculumVitaeConfiguration : IEntityTypeConfiguration<CurriculumVitae>
	{
        public void Configure(EntityTypeBuilder<CurriculumVitae> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasIndex(e => e.Phone).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Position).IsRequired();
            builder.Property(e => e.Gender).IsRequired(false);
            builder.Property(e => e.Region).IsRequired(false);
            builder.Property(e => e.ImageUrl).IsRequired(false);
            builder.Property(e => e.ExpectedSalary).IsRequired(false);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.CurriculumVitaes)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}