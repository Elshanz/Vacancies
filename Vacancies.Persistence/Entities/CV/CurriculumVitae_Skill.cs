using System;
namespace Vacancies.Persistence.Entities
{
	public class CurriculumVitae_Skill
	{
		public int Id { get; set; }
		public int CurriculumVitaeId { get; set; }
		public CurriculumVitae CurriculumVitae { get; set; }
		public int SkillId { get; set; }
		public Skill Skill { get; set; }
	}
}

