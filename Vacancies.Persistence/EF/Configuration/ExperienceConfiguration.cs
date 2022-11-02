using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
	{
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Company).IsRequired();
            builder.Property(e => e.JobTitle).IsRequired();
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();

            builder.HasOne(e => e.CurriculumVitae)
                .WithMany(e => e.Experiences)
                .HasForeignKey(e => e.CurriculumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

