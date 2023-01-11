using System;
using Microsoft.AspNetCore.Mvc;
using Vacancies.Application.Models;
using Vacancies.Application.Services;
using Vacancies.Application.Utils;

namespace Vacancies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class VacancyController : Controller
	{
		private readonly IVacancyService _vacancyService;
		private readonly ITransactionManager _transactionManagaer;
		public VacancyController(
			IVacancyService vacancyService,
            ITransactionManager transactionManagaer)
		{
			_vacancyService = vacancyService;
			_transactionManagaer = transactionManagaer;
		}

		[HttpPost("create-vacancy")]
		public async Task<IActionResult> Create(VacancyToCreate vacancyToCreate)
		{
			return Ok(await _transactionManagaer.HandleTransaction(_vacancyService.CreateAsync, vacancyToCreate));
		}

		[HttpPut("update-vacancy-by-id{id}")]
		public async Task<IActionResult> Update(int id,[FromBody] VacancyToUpdate vacancyToUpdate)
		{
			vacancyToUpdate.Id = id;
			await _transactionManagaer.HandleTransaction(_vacancyService.UpdateVacancyByIdAsync, vacancyToUpdate);
			return Ok();
		}

		[HttpGet("get-vacancy-by-id{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await _vacancyService.GetVacancyById(id));
		}

        [HttpGet("get-vacancies")]
        public async Task<IActionResult> GetVacancies()
        {
            return Ok(await _vacancyService.GetVacanciesAsync());
        }
    }
}

