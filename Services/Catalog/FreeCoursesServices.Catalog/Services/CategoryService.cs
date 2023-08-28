using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService :ICategoryService
    {

        private readonly IMongoCollection<Category> _categoryColletion;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            _categoryColletion = db.GetCollection<Category>(dbSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryColletion.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var category= _mapper.Map<Category>(categoryDto);
            await _categoryColletion.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category= await _categoryColletion.Find<Category>(item => item.Id==id).FirstOrDefaultAsync();
            if(category==null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}



/*
Internal
Kendi projesi içerisinde public,
farklı bir projeden/dışarıdan
çağırılmak istenildiğinde ise
private özelliklerini taşır.
Yani aynı Assembly (dll) üzerinde istediğiniz şekilde kullanabilirsiniz ancak dışarıdan
(farklı bir projeden) çağıramazsınız.
 */