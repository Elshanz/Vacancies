using System;
namespace Vacancies.Persistence.Entities
{
	public class Vacancy : BaseEntity
	{
		public string Recruiter { get; set; }
		public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public int AgeRequirement { get; set; }
        public string Gender { get; set; }
        public int ContactNumber { get; set; }  
        public string Email { get; set; }
        public string Region { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Vacancy_Skill> Vacancy_Skills { get; set; }
    }
}

