using System;
using FluentValidation;

namespace Vacancies.Application.Models
{
	public class CategoryToUpdate
	{
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryToUpdateValidator : AbstractValidator<CategoryToUpdate>
    {
        public CategoryToUpdateValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
        }
    }
}

