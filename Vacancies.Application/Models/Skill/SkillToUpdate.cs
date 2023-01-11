using System;
using FluentValidation;

namespace Vacancies.Application.Models
{
	public class SkillToUpdate
	{
        public int SkillId { get; set; }
        public string Name { get; set; }
    }
    public class SkillToUpdateValidator : AbstractValidator<SkillToUpdate>
    {
        public SkillToUpdateValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}

