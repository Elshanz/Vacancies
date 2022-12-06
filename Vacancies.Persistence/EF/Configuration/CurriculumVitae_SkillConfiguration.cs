using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF.Configuration
{
	public class CurriculumVitae_SkillConfiguration : IEntityTypeConfiguration<CurriculumVitae_Skill>
	{
        public void Configure(EntityTypeBuilder<CurriculumVitae_Skill> builder)
        {
            builder.Ignore(e => e.Id);

            builder.HasKey(e => new { e.CurriculumVitaeId, e.SkillId });

            builder.HasOne(e => e.CurriculumVitae)
                .WithMany(e => e.CurriculumVitae_Skills)
                .HasForeignKey(e => e.CurriculumVitaeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(e => e.Skill)
                .WithMany(e => e.CurriculumVitae_Skills)
                .HasForeignKey(e => e.SkillId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

