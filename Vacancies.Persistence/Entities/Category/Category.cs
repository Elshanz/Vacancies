using System;
namespace Vacancies.Persistence.Entities
{
	public class Category : BaseEntity
	{
		public string CategoryName { get; set; }

		public ICollection<Vacancy> Vacancies { get; set; }
		public ICollection<CurriculumVitae> CurriculumVitaes { get; set; }
	}
}

