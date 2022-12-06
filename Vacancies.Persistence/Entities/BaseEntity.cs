using System;
namespace Vacancies.Persistence.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
	}
}