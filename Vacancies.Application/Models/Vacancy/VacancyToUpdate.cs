using System;
using FluentValidation;

namespace Vacancies.Application.Models
{
	public class VacancyToUpdate
	{
        public int Id { get; set; }
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

        public int CategoryId { get; set; }
        public ICollection<Vacancy_SkillDto> Vacancy_Skills { get; set; }
    }

    public class VacancyToUpdateValidator : AbstractValidator<VacancyToUpdate>
    {
        public VacancyToUpdateValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Recruiter).NotEmpty();
            RuleFor(x => x.JobTitle).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Education).NotEmpty();
            RuleFor(x => x.Experience).NotEmpty();
            RuleFor(x => x.AgeRequirement).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.ContactNumber).NotEmpty();
            RuleFor(x => x.Salary).NotEmpty();
            RuleFor(x => x.Region).NotEmpty();
        }
    }
}

