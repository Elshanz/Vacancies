using System;
namespace Vacancies.Persistence.Entities
{
	public class Education
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Profession { get; set; }
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

