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
    public class CategoryManager : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryColection;
        public IMapper _mapper { get; set; }

        public CategoryManager(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _categoryColection = database.GetCollection<Category>(databaseSetting.CategoryCollectionName);
            _mapper = mapper;

        }

        public async Task<ResponseModel<List<CategoryDto>>> GetAllAsyn()
        {
            var categories = await _categoryColection.Find(categories => true).ToListAsync();
            return ResponseModel<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<ResponseModel<CategoryDto>> CreateAsyn(CategoryDto category)
        {
            await _categoryColection.InsertOneAsync(_mapper.Map<Category>(category));
            return ResponseModel<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<ResponseModel<CategoryDto>> getbyIdAsyn(string Id)
        {
            var category = await _categoryColection.Find<Category>(x => x.Id == Id).FirstOrDefaultAsync();

            if (category == null)
            {
                return ResponseModel<CategoryDto>.Error("Böyle bir kategori bulunmamaktadır", 404);
            }
            return ResponseModel<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
