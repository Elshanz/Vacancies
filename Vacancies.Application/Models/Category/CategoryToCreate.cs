using System;
using FluentValidation;

namespace Vacancies.Application.Models
{
	public class CategoryToCreate
	{
        public string CategoryName { get; set; }
    }

    public class CategoryToCreateValidator : AbstractValidator<CategoryToCreate>
    {
        public CategoryToCreateValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
        }
    }
}

