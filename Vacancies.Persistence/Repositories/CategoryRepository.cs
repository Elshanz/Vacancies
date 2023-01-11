using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.EF;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.Repositories
{
	public interface ICategoryRepository
	{
        Task<Category> CreateAsync(Category category);
        Task<Category> GetAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _dbSet;
        public CategoryRepository(VacanciesDbContext context)
        {
            _dbSet = context.Set<Category>();
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var entry = await _dbSet.AddAsync(category);
            return entry.Entity;
        }

        public async Task<Category> GetAsync(int categoryId)
        {
            return await _dbSet.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbSet.ToArrayAsync();
        }
    }
}

