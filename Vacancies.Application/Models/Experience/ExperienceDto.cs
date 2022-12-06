using System;
namespace Vacancies.Application.Models
{
	public class ExperienceDto
	{
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}