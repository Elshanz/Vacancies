using System;
using Vacancies.Application.Models;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface IExperienceService
	{
        Task<int> CreateAsync(ExperienceToCreate experienceToCreate);
        Task<ExperienceDto> GetExperience(int experienceId);
	}
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExperienceService(IExperienceRepository experienceRepository,
            IUnitOfWork unitOfWork)
        {
            _experienceRepository = experienceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(ExperienceToCreate experienceToCreate)
        {
            var experience = new Experience
            {
                Company = experienceToCreate.Company,
                JobTitle = experienceToCreate.JobTitle,
                StartDate = experienceToCreate.StartDate,
                EndDate = experienceToCreate.EndDate
            };

            var result = await _experienceRepository.CreateAsync(experience);

            await _unitOfWork.SaveChangesAsync();
            
            return result.Id;
        }

        public Task<ExperienceDto> GetExperience(int experienceId)
        {
            throw new NotImplementedException();
        }
    }
}

