using System;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Vacancies.Application.Models;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface ICurriculumVitaeService
	{
        Task<IEnumerable<CurriculumVitaeDto>> GetCVsAsync();
        Task<CurriculumVitaeDto> GetCVByIdAsync(int cvId);
        Task<int> CreateAsync(CurriculumVitaeToCreate curriculumVitaeToCreate);
        Task UpdateCVByIdAsync(CurriculumVitaeToUpdate curriculumVitaeToUpdate);
    }
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly ICurriculumVitaeRepository _curriculumVitaeRepository;
        private readonly ILogger<CurriculumVitaeService> _logger;
        private readonly IValidator<CurriculumVitaeToCreate> _curriculumVitaeToCreateValidator;
        private readonly IValidator<CurriculumVitaeToUpdate> _curriculumVitaeToUpdateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public CurriculumVitaeService(
            ICurriculumVitaeRepository curriculumVitaeRepository,
            ILogger<CurriculumVitaeService> logger,
            IValidator<CurriculumVitaeToCreate> curriculumVitaeToCreateValidator,
            IValidator<CurriculumVitaeToUpdate> curriculumVitaeToUpdateValidator,
            IUnitOfWork unitOfWork
            )
        {
            _curriculumVitaeRepository = curriculumVitaeRepository;
            _logger = logger;
            _curriculumVitaeToCreateValidator = curriculumVitaeToCreateValidator;
            _curriculumVitaeToUpdateValidator = curriculumVitaeToUpdateValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CurriculumVitaeToCreate curriculumVitaeToCreate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CurriculumVitaeService.CreateAsync()");

            // Validate input
            _curriculumVitaeToCreateValidator.ValidateAndThrow(curriculumVitaeToCreate);

            // Map input to entity
            var cv = new CurriculumVitae
            {
                Name = curriculumVitaeToCreate.Name,
                Surname = curriculumVitaeToCreate.Surname,
                Position = curriculumVitaeToCreate.Position,
                ExpectedSalary = curriculumVitaeToCreate.ExpectedSalary,
                Age = curriculumVitaeToCreate.Age,
                ImageUrl = curriculumVitaeToCreate.ImageUrl,
                Gender = curriculumVitaeToCreate.Gender,
                Phone = curriculumVitaeToCreate.Phone,
                Email = curriculumVitaeToCreate.Email,
                Description = curriculumVitaeToCreate.Description,
                Region = curriculumVitaeToCreate.Region,
                PublishedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddDays(30),
                CategoryId = curriculumVitaeToCreate.CategoryId,

                Educations = curriculumVitaeToCreate.Educations.Select(n => new Education
                {
                    Degree = n.Degree,
                    Institution = n.Institution,
                    Profession = n.Profession,
                    StartDate = n.StartDate,
                    EndDate = n.EndDate
                }).ToList(),

                Experiences = curriculumVitaeToCreate.Experiences.Select(n => new Experience
                {
                    Company = n.Company,
                    JobTitle = n.JobTitle,
                    StartDate = n.StartDate,
                    EndDate = n.EndDate
                }).ToList(),

                CurriculumVitae_Skills = curriculumVitaeToCreate.SkillIds.Select(skillId => new CurriculumVitae_Skill
                {
                    SkillId = skillId
                }).ToList()
            };

            var result = await _curriculumVitaeRepository.CreateAsync(cv);

            // Save entity
            await _unitOfWork.SaveChangesAsync();

            // Return id
            return result.Id;
        }

        public async Task<IEnumerable<CurriculumVitaeDto>> GetCVsAsync()
        {
            // Logging to File
            _logger.LogInformation("Executing Action CurriculumVitaeService.GetCVsAsync()");

            var cvs = await _curriculumVitaeRepository.GetCVsAsync();

            return cvs.Select(cv => new CurriculumVitaeDto
            {
                Name = cv.Name,
                Surname = cv.Surname,
                Position = cv.Position,
                Age = cv.Age,
                Email = cv.Email,
                Phone = cv.Phone,
                Gender = cv.Gender,
                ImageUrl = cv.ImageUrl,
                Description = cv.Description,
                Region = cv.Region,
                ExpectedSalary = cv.ExpectedSalary,
                PublishedOn = cv.PublishedOn,
                ExpiresOn = cv.ExpiresOn,
                CategoryId = cv.CategoryId,

                Educations = cv.Educations.Select(edu => new EducationDto
                {
                    Degree = edu.Degree,
                    Institution = edu.Institution,
                    Profession = edu.Profession,
                    StartDate = edu.StartDate,
                    EndDate = edu.EndDate
                }).ToList(),

                Experiences = cv.Experiences.Select(ex => new ExperienceDto
                {
                    Company = ex.Company,
                    JobTitle = ex.JobTitle,
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate
                }).ToList(),

                CurriculumVitae_Skills = cv.CurriculumVitae_Skills.Select(cs => new CurriculumVitae_SkillDto
                {
                    CurriculumVitaeId = cs.CurriculumVitaeId,
                    SkillId = cs.SkillId
                }).ToList()
            }).ToList();
        }

        public async Task<CurriculumVitaeDto> GetCVByIdAsync(int cvId)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CurriculumVitaeService.GetAsync()");

            var cv = await _curriculumVitaeRepository.GetAsync(cvId);

            if (cv is null) return null;

            return new CurriculumVitaeDto
            {
                Name = cv.Name,
                Surname = cv.Surname,
                Position = cv.Position,
                Age = cv.Age,
                Email = cv.Email,
                Phone = cv.Phone,
                Gender = cv.Gender,
                ImageUrl = cv.ImageUrl,
                Description = cv.Description,
                Region = cv.Region,
                ExpectedSalary = cv.ExpectedSalary,
                PublishedOn = cv.PublishedOn,
                ExpiresOn = cv.ExpiresOn,
                CategoryId = cv.CategoryId,

                Educations = cv.Educations.Select(edu => new EducationDto
                {
                    Degree = edu.Degree,
                    Institution = edu.Institution,
                    Profession = edu.Profession,
                    StartDate = edu.StartDate,
                    EndDate = edu.EndDate
                }).ToList(),

                Experiences = cv.Experiences.Select(ex => new ExperienceDto
                {
                    Company = ex.Company,
                    JobTitle = ex.JobTitle,
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate
                }).ToList(),

                CurriculumVitae_Skills = cv.CurriculumVitae_Skills.Select(cs => new CurriculumVitae_SkillDto
                {
                    CurriculumVitaeId = cs.CurriculumVitaeId,
                    SkillId = cs.SkillId
                }).ToList()
            };
        }

        public async Task UpdateCVByIdAsync(CurriculumVitaeToUpdate curriculumVitaeToUpdate)
        {
            // Logging to File
            _logger.LogInformation("Executing Action CurriculumVitaeService.GetAsync()");

            // Validate input
            _curriculumVitaeToUpdateValidator.ValidateAndThrow(curriculumVitaeToUpdate);

            // Get the entity
            var cv = await _curriculumVitaeRepository.GetAsync(curriculumVitaeToUpdate.Id);

            // Map input to entity
            cv.Name = curriculumVitaeToUpdate.Name;
            cv.Surname = curriculumVitaeToUpdate.Surname;
            cv.Position = curriculumVitaeToUpdate.Position;
            cv.Description = curriculumVitaeToUpdate.Description;
            cv.Age = curriculumVitaeToUpdate.Age;
            cv.Email = curriculumVitaeToUpdate.Email;
            cv.Gender = curriculumVitaeToUpdate.Gender;
            cv.ExpectedSalary = curriculumVitaeToUpdate.ExpectedSalary;
            cv.ImageUrl = curriculumVitaeToUpdate.ImageUrl;
            cv.Region = curriculumVitaeToUpdate.Region;
            cv.Category.Id = curriculumVitaeToUpdate.CategoryId;

            cv.Educations = curriculumVitaeToUpdate.Educations.Select(edu => new Education
            {
                Degree = edu.Degree,
                Institution = edu.Institution,
                Profession = edu.Profession,
                StartDate = edu.StartDate,
                EndDate = edu.EndDate
            }).ToList();

            cv.Experiences = curriculumVitaeToUpdate.Experiences.Select(ex => new Experience
            {
                Company = ex.Company,
                JobTitle = ex.JobTitle,
                Description = ex.Description,
                StartDate = ex.StartDate,
                EndDate = ex.EndDate
            }).ToList();

            cv.CurriculumVitae_Skills = curriculumVitaeToUpdate.CurriculumVitae_Skills.Select(cs => new CurriculumVitae_Skill
            {
                CurriculumVitaeId = cs.CurriculumVitaeId,
                SkillId = cs.SkillId
            }).ToList();

            // Save entity
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

