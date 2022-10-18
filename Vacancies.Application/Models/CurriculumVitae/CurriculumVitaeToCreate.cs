using System;
using Vacancies.Persistence.Entities;

namespace Vacancies.Application.Models.CurriculumVitae
{
	public class CurriculumVitaeToCreate
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int ExpectedSalary { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public DateTime PublishedOn { get; set; }

        public ICollection<CurriculumVitae_EducationDto> CurriculumVitae_Educations { get; set; }
        public ICollection<CurriculumVitae_ExperienceDto> CurriculumVitae_Experiences { get; set; }
        public ICollection<CurriculumVitae_Skill> CurriculumVitae_Skills { get; set; }
    }
}

