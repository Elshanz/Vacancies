using System;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Vacancies.Application.Models;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface ISkillService
	{
        Task<SkillDto> GetSkillByIdAsync(int skillId);
        Task<int> CreateAsync(SkillToCreate skillToCreate);
        Task UpdateSkillByIdAsync(SkillToUpdate skillToUpdate);
        Task<IEnumerable<SkillDto>> GetSkillsAsync();
	}
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISkillRepository _skillRepository;
        private readonly IValidator<SkillToCreate> _skillToCreateValidator;
        private readonly IValidator<SkillToUpdate> _skillToUpdateValidator;
        private readonly ILogger<SkillService> _logger;
        public SkillService(
            IUnitOfWork unitOfWork,
            ISkillRepository skillRepository,
            IValidator<SkillToCreate> skillToCreateValidator,
            IValidator<SkillToUpdate> skillToUpdateValidator,
            ILogger<SkillService> logger)
        {
            _unitOfWork = unitOfWork;
            _skillRepository = skillRepository;
            _skillToCreateValidator = skillToCreateValidator;
            _skillToUpdateValidator = skillToUpdateValidator;
            _logger = logger;
        }

        public async Task<int> CreateAsync(SkillToCreate skillToCreate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action SkillService.CreateAsync()");

            // Validate the input
            _skillToCreateValidator.ValidateAndThrow(skillToCreate);

            // Map the input to entity
            var skill = new Skill()
            {
                Name = skillToCreate.Name
            };

            var result = await _skillRepository.CreateAsync(skill);

            try
            {
                // Save entity
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            // return id
            return result.Id;
        }

        public async Task<SkillDto> GetSkillByIdAsync(int skillId)
        {
            // Logging to File
            _logger.LogInformation("Executing Action SkillService.GetSkillByIdAsync()");

            // get the entity
            var skill = await _skillRepository.GetAsync(skillId);

            // check the entity if exist
            if (skill is null) return null;

            // return the entity
            return new SkillDto
            {
                Name = skill.Name
            };
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsAsync()
        {
            var skills = await _skillRepository.GetSkills();

            return skills.Select(s => new SkillDto
            {
                Name = s.Name
            }).ToList();
        }

        public async Task UpdateSkillByIdAsync(SkillToUpdate skillToUpdate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action SkillService.UpdateSkillByIdAsync()");

            // Validate the input
            _skillToUpdateValidator.ValidateAndThrow(skillToUpdate);

            // Get the entity
            var skill = await _skillRepository.GetAsync(skillToUpdate.SkillId);

            // Map the input to entity
            skill.Name = skillToUpdate.Name;

            // Save entity
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

