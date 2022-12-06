using System;
namespace Vacancies.Persistence.Entities
{
	public class Experience : BaseEntity
	{
		public string Company { get; set; }
		public string JobTitle { get; set; }
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
		public string? Description { get; set; }

		public int CurriculumId { get; set; }
		public CurriculumVitae CurriculumVitae { get; set; }
	}
}