using System;
using Microsoft.AspNetCore.Mvc;
using Vacancies.Application.Models;
using Vacancies.Application.Services;

namespace Vacancies.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CurriculumVitaeController : Controller
	{
		private readonly ICurriculumVitaeService _curriculumVitaeService;

		public CurriculumVitaeController(ICurriculumVitaeService curriculumVitaeService)
		{
			_curriculumVitaeService = curriculumVitaeService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCVById(int id)
		{
			return Ok(await _curriculumVitaeService.GetAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CurriculumVitaeToCreate curriculumVitaeToCreate)
		{
			return Ok(await _curriculumVitaeService.CreateAsync(curriculumVitaeToCreate));
		}
	}
}

