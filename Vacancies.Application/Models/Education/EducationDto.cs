using System;
namespace Vacancies.Application.Models.Education
{
	public class EducationDto
	{
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Profession { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

