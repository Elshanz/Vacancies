
using System;
namespace Vacancies.Persistence.Entities
{
	public class Skill : BaseEntity
	{
		public string Name { get; set; }

		public int CurriculumVitaeId { get; set; }
		public CurriculumVitae CurriculumVitae { get; set; }

		public int VacancyId { get; set; }
		public Vacancy Vacancy { get; set; }

		public ICollection<CurriculumVitae_Skill> CurriculumVitae_Skills { get; set; }
		public ICollection<Vacancy_Skill> Vacancy_Skills { get; set; }
	}
}

