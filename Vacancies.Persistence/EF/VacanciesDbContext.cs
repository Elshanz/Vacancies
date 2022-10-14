using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.EF
{
	internal class VacanciesDbContext : DbContext
	{
		public VacanciesDbContext(DbContextOptions<VacanciesDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
		public DbSet<CurriculumVitae_Education> CurriculumVitae_Educations { get; set; }
        public DbSet<CurriculumVitae_Experience> CurriculumVitae_Experiences { get; set; }
        public DbSet<CurriculumVitae_Skill> CurriculumVitae_Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Vacancy_Skill> Vacancy_Skills { get; set; }
    }
}

