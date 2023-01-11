using System;
using Microsoft.AspNetCore.Mvc;
using Vacancies.Application.Models;
using Vacancies.Application.Services;
using Vacancies.Application.Utils;

namespace Vacancies.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SkillController : Controller
	{
		private readonly ISkillService _skillService;
		private readonly ITransactionManager _transactionManager;
		public SkillController(ISkillService skillService, ITransactionManager transactionManager)
		{
			_skillService = skillService;
			_transactionManager = transactionManager;
		}

		[HttpPost("create-skill")]
		public async Task<IActionResult> Create(SkillToCreate skillToCreate)
		{
			return Ok(await _transactionManager.HandleTransaction(_skillService.CreateAsync, skillToCreate));
		}

		[HttpPut("update-skill-by-id/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] SkillToUpdate skillToUpdate)
		{
			skillToUpdate.SkillId = id;
			await _transactionManager.HandleTransaction(_skillService.UpdateSkillByIdAsync, skillToUpdate);
			return Ok();
		}

		[HttpGet("get-skill-by-id/{id}")]
		public async Task<IActionResult> GetSkill(int id)
		{
			return Ok(await _skillService.GetSkillByIdAsync(id));
		}

        [HttpGet("get-skills")]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _skillService.GetSkillsAsync());
        }
    }
}

