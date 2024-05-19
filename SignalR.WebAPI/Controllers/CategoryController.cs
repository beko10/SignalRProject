using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]   
        public IActionResult CategoryList() 
        {
            var categories = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetAll());   
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var createdCategory =_mapper.Map<Category>(createCategoryDto);
            //Category createdCategory = new Category
            //{
            //    CategoryName=createCategoryDto.CategoryName,
            //    Status=createCategoryDto.Status,    
            //};
            _categoryService.Add(createdCategory);  
            return Ok(createdCategory); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            var deletedCategory = _categoryService.GetById(id); 
            _categoryService.Delete(deletedCategory);   
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.Update(updatedCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount() 
        {
            var categoryCount =  _categoryService.CategoryCount();
            return Ok(categoryCount);
        }

        [HttpGet("CategorySatatusTrueCount")]
        public IActionResult CategorySatatusTrueCount()
        {
            var CategoryStatusTrueCount = _categoryService.CategorySatatusTrueCount();
            return Ok(CategoryStatusTrueCount); 
        }

        [HttpGet("CategorySatatusFalseCount")]
        public IActionResult  CategorySatatusFalseCount()
        {

            var CategoryStatusFalseCount = _categoryService.CategorySatatusFalseCount();
            return Ok(CategoryStatusFalseCount);
        }



    }
}
