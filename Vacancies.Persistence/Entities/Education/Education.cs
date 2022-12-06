using System;
namespace Vacancies.Persistence.Entities
{
	public class Education : BaseEntity
	{
		public string Degree { get; set; }
		public string Institution { get; set; }
		public string Profession { get; set; }
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

		public int CurriculumId { get; set; }
		public CurriculumVitae CurriculumVitae { get; set; }
	}
}

