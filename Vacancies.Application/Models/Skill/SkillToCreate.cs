using System;
using FluentValidation;

namespace Vacancies.Application.Models
{
	public class SkillToCreate
	{
        public string Name { get; set; }
    }
    public class SkillToCreateValidator : AbstractValidator<SkillToCreate>
    {
        public SkillToCreateValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}

