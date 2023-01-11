
using System;
namespace Vacancies.Persistence.Entities
{
	public class Skill : BaseEntity
	{
		public string Name { get; set; } 

		public ICollection<CurriculumVitae_Skill> CurriculumVitae_Skills { get; set; }
		public ICollection<Vacancy_Skill> Vacancy_Skills { get; set; }
	}
}

