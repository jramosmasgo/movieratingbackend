using AutoMapper;
using MovieRating.Entities;
using MovieRating.Mapping.CategoryViewModel;
using MovieRating.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRating.Features
{
    public class Categories
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepositoryAsync _categoryRepository;

        public Categories(IMapper mapper, ICategoryRepositoryAsync categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<IEnumerable<GetCategoryViewModel>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetCategoryViewModel>>(categories);
            return new Response<IEnumerable<GetCategoryViewModel>>(results, "Operation Successfully");
        }

        public async Task<Response<GetCategoryViewModel>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetCategoryViewModel>(category);
            return new Response<GetCategoryViewModel>(result, "Operation Succesfullly");
        }

        public async Task<Response<GetCategoryViewModel>> CreateCategory(CreateCategoryViewModel categoryViewModel)
        {
            var categoryToAdd = _mapper.Map<Category>(categoryViewModel);
            var result = await _categoryRepository.AddAync(categoryToAdd);
            return new Response<GetCategoryViewModel>(_mapper.Map<GetCategoryViewModel>(result), "Operation Successfully");
        }
    }
}
