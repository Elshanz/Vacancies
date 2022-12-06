using System;
namespace Vacancies.Persistence.Entities
{
	public class Vacancy_Skill : BaseEntity
	{
		public int VacancyId { get; set; }
		public Vacancy Vacancy { get; set; }
		public int SkillId { get; set; }
		public Skill Skill { get; set; }
	}
}

