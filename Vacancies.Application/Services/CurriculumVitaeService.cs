using System;
using Vacancies.Application.Models.CurriculumVitae;
using Vacancies.Persistence;
using Vacancies.Persistence.Entities;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Application.Services
{
	public interface ICurriculumVitaeService
	{
        Task<IEnumerable<CurriculumVitaeDto>> GetAllAsync();
        Task<CurriculumVitaeDetailsDto> GetAsync(int cvId);
        Task<int> CreateAsync(CurriculumVitaeToCreate curriculumVitaeToCreate);
        Task UpdateAsync(CurriculumVitaeToUpdate curriculumVitaeToCreate);
        //salam
    }
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly ICurriculumVitaeRepository _curriculumVitaeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CurriculumVitaeService(
            ICurriculumVitaeRepository curriculumVitaeRepository,
            IUnitOfWork unitOfWork
            )
        {
            _curriculumVitaeRepository = curriculumVitaeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CurriculumVitaeToCreate curriculumVitaeToCreate)
        {
            var cv = new CurriculumVitae
            {
                Name = curriculumVitaeToCreate.Name,
                Surname = curriculumVitaeToCreate.Surname,
                Position = curriculumVitaeToCreate.Position,
                ExpectedSalary = curriculumVitaeToCreate.ExpectedSalary,
                Age = curriculumVitaeToCreate.Age,
                Gender = curriculumVitaeToCreate.Gender,
                Phone = curriculumVitaeToCreate.Phone,
                Email = curriculumVitaeToCreate.Email,
                Description = curriculumVitaeToCreate.Description,
                Region = curriculumVitaeToCreate.Region,
                PublishedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddDays(30),

                CurriculumVitae_Educations = curriculumVitaeToCreate.CurriculumVitae_Educations.Select(n => new CurriculumVitae_Education
                {
                    CurriculumVitaeId = n.CurriculumVitaeId,
                    EducationId = n.EducationId
                }).ToList(),

                CurriculumVitae_Experiences = curriculumVitaeToCreate.CurriculumVitae_Experiences.Select(n => new CurriculumVitae_Experience
                {
                    CurriculumVitaeId = n.CurriculumVitaeId,
                    ExperienceId = n.ExperienceId
                }).ToList(),

                CurriculumVitae_Skills = curriculumVitaeToCreate.CurriculumVitae_Skills.Select(n => new CurriculumVitae_Skill
                {
                    CurriculumVitaeId = n.CurriculumVitaeId,
                    SkillId = n.SkillId
                }).ToList()
            };

            var result = await _curriculumVitaeRepository.CreateAsync(cv);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }

        public Task<IEnumerable<CurriculumVitaeDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CurriculumVitaeDetailsDto> GetAsync(int cvId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CurriculumVitaeToUpdate curriculumVitaeToCreate)
        {
            throw new NotImplementedException();
        }
    }
}

