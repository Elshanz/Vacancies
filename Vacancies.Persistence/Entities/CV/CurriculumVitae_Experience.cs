using System;
namespace Vacancies.Persistence.Entities
{
	public class CurriculumVitae_Experience
	{
        public int Id { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}

