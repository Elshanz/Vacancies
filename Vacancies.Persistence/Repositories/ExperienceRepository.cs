using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.EF;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.Repositories
{
	public interface IExperienceRepository
	{
        Task<Experience> GetAsync(int experienceId);
        Task<Experience> CreateAsync(Experience experience);
    }
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly DbSet<Experience> _dbSet; 
        public ExperienceRepository(VacanciesDbContext context)
        {
            _dbSet = context.Set<Experience>();
        }

        public async Task<Experience> CreateAsync(Experience experience)
        {
            var entry = await _dbSet.AddAsync(experience);
            return entry.Entity;
        }

        public async Task<Experience> GetAsync(int experienceId)
        {
            return await _dbSet.FirstOrDefaultAsync(n => n.Id == experienceId);
        }
    }
}

