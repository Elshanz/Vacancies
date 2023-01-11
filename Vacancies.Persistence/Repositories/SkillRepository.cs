using System;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.EF;
using Vacancies.Persistence.Entities;

namespace Vacancies.Persistence.Repositories
{
	public interface ISkillRepository
	{
        Task<Skill> CreateAsync(Skill skill);
        Task<Skill> GetAsync(int skillId);
        Task<IEnumerable<Skill>> GetSkills();
	}
    public class SkillRepository : ISkillRepository
    {
        private readonly DbSet<Skill> _dbSet;
        public SkillRepository(VacanciesDbContext context)
        {
            _dbSet = context.Set<Skill>();
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            var entry = await _dbSet.AddAsync(skill);
            return entry.Entity;
        }

        public async Task<Skill> GetAsync(int skillId)
        {
            return await _dbSet.FindAsync(skillId);
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await _dbSet.ToArrayAsync();
        }
    }
}

