using System;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Vacancies.Application.Models;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface ICategoryService
	{
        Task<CategoryDto> GetCategoryById(int categoryId);
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<int> CreateAsync(CategoryToCreate categoryToCreate);
        Task UpdateAsync(CategoryToUpdate categoryToUpdate);
	}
    public class CategoryService : ICategoryService
    {
        private readonly IValidator<CategoryToCreate> _categoryToCreateValidator;
        private readonly IValidator<CategoryToUpdate> _categoryToUpdateValidator;
        private readonly ILogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(
            IValidator<CategoryToCreate> categoryToCreateValidator,
            IValidator<CategoryToUpdate> categoryToUpdateValidator,
            ILogger<CategoryService> logger,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryToCreateValidator = categoryToCreateValidator;
            _categoryToUpdateValidator = categoryToUpdateValidator;
            _logger = logger;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CategoryToCreate categoryToCreate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CategoryService.CreateAsync()");

            // Validate input 
            _categoryToCreateValidator.ValidateAndThrow(categoryToCreate);

            // Map input to entity
            var category = new Category()
            {
                CategoryName = categoryToCreate.CategoryName
            };

            var result = await _categoryRepository.CreateAsync(category);

            // Save entity
            await _unitOfWork.SaveChangesAsync();

            // Return id
            return result.Id;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            // Logging to File
            _logger.LogInformation("Executing Action CategoryService.GetCategories()");

            var categories = await _categoryRepository.GetCategories();

            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            });
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CategoryService.GetCategoryById()");

            var category = await _categoryRepository.GetAsync(categoryId);

            if (category == null) return null;

            return new CategoryDto()
            {
                CategoryName = category.CategoryName
            };
        }

        public async Task UpdateAsync(CategoryToUpdate categoryToUpdate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CategoryService.UpdateAsync()");

            // Validate input 
            _categoryToUpdateValidator.ValidateAndThrow(categoryToUpdate);

            // Map input to entity
            var category = await _categoryRepository.GetAsync(categoryToUpdate.Id);

            category.CategoryName = categoryToUpdate.CategoryName;

            // Save entity
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

