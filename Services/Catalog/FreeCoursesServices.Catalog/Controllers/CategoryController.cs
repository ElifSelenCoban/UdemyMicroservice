using System;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controller
{

    [Route("api/[controller]")]
    [ApiController]

    public class CatagoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CatagoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region actions
        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)

        {
            var categories = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
           var response= await _categoryService.CreateCategoryAsync(categoryDto);
            return CreateActionResultInstance(response);
        }
        #endregion

    }
}

