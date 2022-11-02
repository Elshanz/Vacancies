using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
	{
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Recruiter).IsRequired();
            builder.Property(e => e.JobTitle).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Education).IsRequired();
            builder.Property(e => e.Experience).IsRequired();
            builder.Property(e => e.Salary).IsRequired();
            builder.Property(e => e.AgeRequirement).IsRequired();
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Region).IsRequired();
            builder.Property(e => e.ContactNumber).IsRequired();
            builder.Property(e => e.Email).IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Vacancies)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

