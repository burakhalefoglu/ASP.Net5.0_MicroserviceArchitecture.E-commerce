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
    public class ProductController : CustomerBaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await productService.getbyIdAsyn(id);
            return CreateActionResult(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await productService.GetAllAsyn();
            return CreateActionResult(response);
        }


        [HttpPost()]
        public async Task<IActionResult> create(CreateProductDto productDto)
        {
            var response = await productService.CreateAsyn(productDto);
            return CreateActionResult(response);
        }

        [HttpPut()]
        public async Task<IActionResult> update(UpdateProductDto productDto)
        {
            var response = await productService.UpdateProductAsyn(productDto);
            return CreateActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(string id)
        {
            var response = await productService.DeleteProductAsyn(id);
            return CreateActionResult(response);
        }
    }
}
