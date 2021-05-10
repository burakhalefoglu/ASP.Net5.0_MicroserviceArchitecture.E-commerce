using Products.services.Models;
using Products.services.Models.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseModel<List<CategoryDto>>> GetAllAsyn();
        Task<ResponseModel<CategoryDto>> CreateAsyn(CategoryDto category);
        Task<ResponseModel<CategoryDto>> getbyIdAsyn(string Id);
    }
}
