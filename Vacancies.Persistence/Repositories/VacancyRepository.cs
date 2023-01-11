using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.EF;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.Repositories
{
	public interface IVacancyRepository
	{
        Task<Vacancy> CreateAsync(Vacancy vacancy);
        Task<Vacancy> GetAsync(int vacancyId);
        Task<IEnumerable<Vacancy>> GetVacanciesAsync();
	}
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DbSet<Vacancy> _dbSet;
        public VacancyRepository(VacanciesDbContext context)
        {
            _dbSet = context.Set<Vacancy>();
        }

        public async Task<Vacancy> CreateAsync(Vacancy vacancy)
        {
            var entry = await _dbSet.AddAsync(vacancy);
            return entry.Entity;
        }

        public async Task<Vacancy> GetAsync(int vacancyId)
        {
            return await _dbSet.FindAsync(vacancyId);
        }

        public async Task<IEnumerable<Vacancy>> GetVacanciesAsync()
        {
            return await _dbSet.ToArrayAsync();
        }
    }
}

