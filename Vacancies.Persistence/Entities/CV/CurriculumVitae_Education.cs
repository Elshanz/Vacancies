using System;
namespace Vacancies.Persistence.Entities
{
	public class CurriculumVitae_Education
	{
        public int Id { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
