using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.services.Models.DTOs;
using Products.services.Services.Abstract;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomerBaseController
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.getbyIdAsyn(id);
            return CreateActionResult(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsyn();
            return CreateActionResult(response);
        }


        [HttpPost()]
        public async Task<IActionResult> create(CategoryDto categoryDto)
        {
            var response = await _categoryService.CreateAsyn(categoryDto);
            return CreateActionResult(response);
        }
    }
}
