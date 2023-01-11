using System;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Vacancies.Application.Models;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface IVacancyService
	{
        Task<int> CreateAsync(VacancyToCreate vacancyToCreate);
        Task UpdateVacancyByIdAsync(VacancyToUpdate vacancyToUpdate);
        Task<VacancyDto> GetVacancyById(int vacancyId);
        Task<IEnumerable<VacancyDto>> GetVacanciesAsync();
	}
    public class VacancyService : IVacancyService
    {
        private readonly ILogger<SkillService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IValidator<VacancyToCreate> _vacancyToCreateValidator;
        private readonly IValidator<VacancyToUpdate> _vacancyToUpdateValidator;

        public VacancyService(
            ILogger<SkillService> logger,
            IUnitOfWork unitOfWork,
            IVacancyRepository vacancyRepository,
            IValidator<VacancyToCreate> vacancyToCreateValidator,
            IValidator<VacancyToUpdate> vacancyToUpdateValidator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _vacancyRepository = vacancyRepository;
            _vacancyToCreateValidator = vacancyToCreateValidator;
            _vacancyToUpdateValidator = vacancyToUpdateValidator;
        }

        public async Task<int> CreateAsync(VacancyToCreate vacancyToCreate)
        {
            // 1. Logging to file
            _logger.LogInformation("Executing Action VacancyService.CreateAsync()");

            // 2. Validate the input
            _vacancyToCreateValidator.ValidateAndThrow(vacancyToCreate);

            // 3. Map the input to entity
            var vacancy = new Vacancy()
            {
                Recruiter = vacancyToCreate.Recruiter,
                JobTitle = vacancyToCreate.JobTitle,
                Description = vacancyToCreate.Description,
                Education = vacancyToCreate.Education,
                Experience = vacancyToCreate.Experience,
                AgeRequirement = vacancyToCreate.AgeRequirement,
                Gender = vacancyToCreate.Gender,
                ContactNumber = vacancyToCreate.ContactNumber,
                Email = vacancyToCreate.Email,
                Salary = vacancyToCreate.Salary,
                Region = vacancyToCreate.Region,

                CategoryId = vacancyToCreate.CategoryId,

                Vacancy_Skills = vacancyToCreate.Vacancy_Skills.Select(vs => new Vacancy_Skill
                {
                    SkillId = vs.SkillId,
                    VacancyId = vs.VacancyId
                }).ToList()
            };

            await _vacancyRepository.CreateAsync(vacancy);

            // 4. Save the entity
            await _unitOfWork.SaveChangesAsync();

            // 5. Return id
            return vacancy.Id;
        }

        public async Task<IEnumerable<VacancyDto>> GetVacanciesAsync()
        {
            // 1. Logging to file
            _logger.LogInformation("Executing Action VacancyService.GetVacanciesAsync()");

            // 2. Get Vacancies from db
            var vacancies = await _vacancyRepository.GetVacanciesAsync();

            // 3. Return the mapped entities
            return vacancies.Select(v => new VacancyDto()
            {
                Recruiter = v.Recruiter,
                JobTitle = v.JobTitle,
                Description = v.Description,
                Education = v.Education,
                Experience = v.Experience,
                AgeRequirement = v.AgeRequirement,
                Gender = v.Gender,
                ContactNumber = v.ContactNumber,
                Email = v.Email,
                Salary = v.Salary,
                Region = v.Region,

                CategoryId = v.CategoryId,

                Vacancy_Skills = v.Vacancy_Skills.Select(vs => new Vacancy_SkillDto
                {
                    SkillId = vs.SkillId,
                    VacancyId = vs.VacancyId
                }).ToList()
            });
        }

        public async Task<VacancyDto> GetVacancyById(int vacancyId)
        {
            // 1. Logging to file
            _logger.LogInformation("Executing Action VacancyService.GetVacancyById()");

            // 2. Get the entity
            var vacancy = await _vacancyRepository.GetAsync(vacancyId);

            // 3. Return the mapped entity
            return new VacancyDto()
            {
                Recruiter = vacancy.Recruiter,
                JobTitle = vacancy.JobTitle,
                Description = vacancy.Description,
                Education = vacancy.Education,
                Experience = vacancy.Experience,
                AgeRequirement = vacancy.AgeRequirement,
                Gender = vacancy.Gender,
                ContactNumber = vacancy.ContactNumber,
                Email = vacancy.Email,
                Salary = vacancy.Salary,
                Region = vacancy.Region,

                CategoryId = vacancy.CategoryId,

                Vacancy_Skills = vacancy.Vacancy_Skills.Select(vs => new Vacancy_SkillDto
                {
                    SkillId = vs.SkillId,
                    VacancyId = vs.VacancyId
                }).ToList()
            };
        }

        public async Task UpdateVacancyByIdAsync(VacancyToUpdate vacancyToUpdate)
        {
            // 1. Logging to file
            _logger.LogInformation("Executing Action VacancyService.UpdateVacancyByIdAsync()");

            // 2. Validate input
            _vacancyToUpdateValidator.ValidateAndThrow(vacancyToUpdate);

            // 3. Get the entity
            var vacancy = await _vacancyRepository.GetAsync(vacancyToUpdate.Id);

            // 4. Map the input to entity
            vacancy.Recruiter = vacancyToUpdate.Recruiter;
            vacancy.JobTitle = vacancyToUpdate.JobTitle;
            vacancy.Description = vacancyToUpdate.Description;
            vacancy.Education = vacancyToUpdate.Education;
            vacancy.Experience = vacancyToUpdate.Experience;
            vacancy.AgeRequirement = vacancyToUpdate.AgeRequirement;
            vacancy.Gender = vacancyToUpdate.Gender;
            vacancy.ContactNumber = vacancyToUpdate.ContactNumber;
            vacancy.Email = vacancyToUpdate.Email;
            vacancy.Salary = vacancyToUpdate.Salary;
            vacancy.Region = vacancyToUpdate.Region;

            vacancy.CategoryId = vacancyToUpdate.CategoryId;

            vacancy.Vacancy_Skills = vacancyToUpdate.Vacancy_Skills.Select(vs => new Vacancy_Skill
            {
                SkillId = vs.SkillId,
                VacancyId = vs.VacancyId
            }).ToList();

            // 5. Save the entity
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

