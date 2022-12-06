using System;
namespace Vacancies.Persistence.Entities
{
	public class CurriculumVitae : BaseEntity
	{
		public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
		public string? Gender { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
        public string Description { get; set; }
        public string? Region { get; set; }
        public string? ImageUrl { get; set; }
        public int? ExpectedSalary { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
        public ICollection<CurriculumVitae_Skill>? CurriculumVitae_Skills { get; set; }
    }
}