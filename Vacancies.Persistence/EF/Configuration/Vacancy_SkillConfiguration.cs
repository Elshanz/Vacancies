using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class Vacancy_SkillConfiguration : IEntityTypeConfiguration<Vacancy_Skill>
	{
        public void Configure(EntityTypeBuilder<Vacancy_Skill> builder)
        {
            builder.Ignore(e => e.Id);

            builder.HasKey(e => new { e.VacancyId, e.SkillId });

            builder.HasOne(e => e.Vacancy)
                .WithMany(e => e.Vacancy_Skills)
                .HasForeignKey(e => e.VacancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Skill)
                .WithMany(e => e.Vacancy_Skills)
                .HasForeignKey(e => e.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

