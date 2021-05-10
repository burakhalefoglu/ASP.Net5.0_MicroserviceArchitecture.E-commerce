using AutoMapper;
using MongoDB.Driver;
using Products.services.Models;
using Products.services.Models.DTOs;
using Products.services.Services.Abstract;
using Products.services.Settings;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IMongoCollection<Product> _productColection;
        private readonly IMongoCollection<Category> _categoryColection;

        public IMapper _mapper { get; set; }

        public ProductManager(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _productColection = database.GetCollection<Product>(databaseSetting.ProductCollectionName);
            _categoryColection = database.GetCollection<Category>(databaseSetting.CategoryCollectionName);
            _mapper = mapper;

        }

        public async Task<ResponseModel<CreateProductDto>> CreateAsyn(CreateProductDto product)
        {

            var newProduct = _mapper.Map<Product>(product);
            await _productColection.InsertOneAsync(newProduct);
            return ResponseModel<CreateProductDto>.Success(_mapper.Map<CreateProductDto>(newProduct), 200);
        }


        public async Task<ResponseModel<List<ProductDto>>> GetAllAsyn()
        {
            var products = await _productColection.Find(products => true).ToListAsync();
            if (products.Any())
            {

                foreach (var product in products)
                {
                    product.Category = await _categoryColection.Find(category => category.Id == product.CategoryId).FirstOrDefaultAsync();

                }
            }
            else
            {
                products = new List<Product>();
            }

            return ResponseModel<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<ResponseModel<ProductDto>> getbyIdAsyn(string Id)
        {
            var product = await _productColection.Find<Product>(x => x.Id == Id).FirstOrDefaultAsync();

            if (product == null)
            {
                return ResponseModel<ProductDto>.Error("Böyle bir ürün bulunmamaktadır", 404);
            }
            product.Category = await _categoryColection.Find(category => category.Id == product.CategoryId).FirstOrDefaultAsync();
            return ResponseModel<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }


        public async Task<ResponseModel<NoContent>> DeleteProductAsyn(string id)
        {
            var result = await _productColection.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount > 0)
            {
                return ResponseModel<NoContent>.Success(204);
            }
            return ResponseModel<NoContent>.Error("ürün bulunamadı..", 404);

        }

        public async Task<ResponseModel<NoContent>> UpdateProductAsyn(UpdateProductDto product)
        {
            var result = await _productColection.FindOneAndReplaceAsync(p => p.Id == product.Id, _mapper.Map<Product>(product));
            if (result == null)
            {
                return ResponseModel<NoContent>.Error("ürün bulunamadı", 404);

            }
            return ResponseModel<NoContent>.Success(204);

        }

    }
}
