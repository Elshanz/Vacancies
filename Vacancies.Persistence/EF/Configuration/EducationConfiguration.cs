using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class EducationConfiguration : IEntityTypeConfiguration<Education>
	{
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Degree).IsRequired();
            builder.Property(e => e.Institution).IsRequired();
            builder.Property(e => e.Profession).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();

            builder.HasOne(e => e.CurriculumVitae)
                .WithMany(e => e.Educations)
                .HasForeignKey(e => e.CurriculumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

