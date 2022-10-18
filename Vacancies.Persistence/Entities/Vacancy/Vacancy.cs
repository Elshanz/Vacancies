using System;
namespace Vacancies.Persistence.Entities
{
	public class Vacancy
	{
		public int Id { get; set; }
		public string Recruiter { get; set; }
		public string JobTitle { get; set; }
		public int Salary { get; set; }
        public int AgeRequirement { get; set; }
        public string GenderRequirement { get; set; }
        public int Phone { get; set; }  
        public string Email { get; set; }
        public string JobDescription { get; set; }
        public string Region { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

        public Category Category { get; set; }
        public Education Education { get; set; }
        public Experience Experience { get; set; }
        public ICollection<Vacancy_Skill> Vacancy_Skills { get; set; }
    }
}

