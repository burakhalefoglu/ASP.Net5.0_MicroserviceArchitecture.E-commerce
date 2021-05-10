using Products.services.Models;
using Products.services.Models.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Services.Abstract
{
    public interface IProductService
    {
        Task<ResponseModel<List<ProductDto>>> GetAllAsyn();
        Task<ResponseModel<CreateProductDto>> CreateAsyn(CreateProductDto product);
        Task<ResponseModel<ProductDto>> getbyIdAsyn(string Id);
        Task<ResponseModel<NoContent>> UpdateProductAsyn(UpdateProductDto product);
        Task<ResponseModel<NoContent>> DeleteProductAsyn(string id);
    }
}
