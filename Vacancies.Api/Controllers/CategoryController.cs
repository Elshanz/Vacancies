using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vacancies.Application.Models;
using Vacancies.Application.Services;
using Vacancies.Application.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vacancies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        private readonly ITransactionManager _transactionManager;
        public CategoryController(ICategoryService categoryservice, ITransactionManager transactionManager)
        {
            _categoryservice = categoryservice;
            _transactionManager = transactionManager;
        }
        [HttpPost("create-category")]
        public async Task<IActionResult> Create(CategoryToCreate categoryToCreate)
        {
            return Ok(await _transactionManager.HandleTransaction(_categoryservice.CreateAsync, categoryToCreate));
        }
        [HttpPut("update-category-by-id/{categoryId}")]
        public async Task<IActionResult> Update(int categoryId, [FromBody] CategoryToUpdate categoryToUpdate)
        {
            categoryToUpdate.Id = categoryId;
            await _transactionManager.HandleTransaction(_categoryservice.UpdateAsync, categoryToUpdate);
            return Ok();
        }
        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await _categoryservice.GetCategoryById(id));
        }
        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryservice.GetCategories());
        }
    }
}

