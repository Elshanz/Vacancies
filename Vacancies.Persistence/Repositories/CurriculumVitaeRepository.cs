using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.EF;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.Repositories
{
    public interface ICurriculumVitaeRepository
    {
        Task<CurriculumVitae> CreateAsync(CurriculumVitae curriculumVitae);
        Task<CurriculumVitae> GetAsync(int cvId);
    }
    public class CurriculumVitaeRepository : ICurriculumVitaeRepository
	{
        private readonly DbSet<CurriculumVitae> _dbSet;

		internal CurriculumVitaeRepository(VacanciesDbContext context)
		{
            _dbSet = context.Set<CurriculumVitae>();
		}

        public async Task<CurriculumVitae> CreateAsync(CurriculumVitae curriculumVitae)
        {
            var cv = await _dbSet.AddAsync(curriculumVitae);
            return cv.Entity;
        }

        public async Task<CurriculumVitae> GetAsync(int cvId)
        {
            return await _dbSet.FindAsync(cvId);
        }
    }
}

