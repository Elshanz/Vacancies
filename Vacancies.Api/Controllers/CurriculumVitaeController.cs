using System;
using Microsoft.AspNetCore.Mvc;
using Vacancies.Application.Models;
using Vacancies.Application.Services;
using Vacancies.Application.Utils;

namespace Vacancies.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CurriculumVitaeController : Controller
	{
		private readonly ICurriculumVitaeService _curriculumVitaeService;
		private readonly ITransactionManager _transactionManager;

		public CurriculumVitaeController(ICurriculumVitaeService curriculumVitaeService, ITransactionManager transactionManager)
		{
			_curriculumVitaeService = curriculumVitaeService;
			_transactionManager = transactionManager;
		}

		[HttpPost("create-cv")]
		public async Task<IActionResult> Create(CurriculumVitaeToCreate curriculumVitaeToCreate)
		{
			return Ok(await _curriculumVitaeService.CreateAsync(curriculumVitaeToCreate));
		}

		[HttpPut("update-cv-by-id/{id}")]
		public async Task<IActionResult> Update(int cvId, [FromBody] CurriculumVitaeToUpdate curriculumVitaeToUpdate)
		{
			curriculumVitaeToUpdate.Id = cvId;
			await _transactionManager.HandleTransaction(_curriculumVitaeService.UpdateCVByIdAsync, curriculumVitaeToUpdate);
			return Ok();
		}

        [HttpGet("get-cv-by-id/{id}")]
        public async Task<IActionResult> GetCVById(int id)
        {
            return Ok(await _curriculumVitaeService.GetCVByIdAsync(id));
        }

		[HttpGet("get-all-cvs")]
		public async Task<IActionResult> GetCVs()
		{
			return Ok(await _curriculumVitaeService.GetCVsAsync());
		}
    }
}

