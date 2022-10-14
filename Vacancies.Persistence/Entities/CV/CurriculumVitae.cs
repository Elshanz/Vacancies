using System;
namespace Vacancies.Persistence.Entities
{
	public class CurriculumVitae
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Surname { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public int Phone { get; set; }
		public string Email { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

        public ICollection<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
    }
}

