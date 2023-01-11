using System;
using FluentValidation;
using Vacancies.Application.Models;
using Vacancies.Persistence.Entities;

namespace Vacancies.Application.Models
{
    public class CurriculumVitaeToCreate
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int ExpectedSalary { get; set; }
        public int Age { get; set; }
        public string? ImageUrl { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public DateTime PublishedOn { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<EducationDto> Educations { get; set; }
        public IEnumerable<ExperienceDto> Experiences { get; set; }
        public ICollection<int> SkillIds { get; set; }
    }

    public class CurriculumVitaeToCreateValidator : AbstractValidator<CurriculumVitaeToCreate>
    {
        public CurriculumVitaeToCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Position).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}