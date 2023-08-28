using System;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controller
{

    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #region actions
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);

        }
        //course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response); // butun methodlar icin response yaratmaya gerek kalmasin diye
            //shared altina topladik.Returnde herhangi bir tip belirtmeye gerek kalmadik.

        }
        //course/5 ayni calisir bunlari ayirmak gerekiyor.Route ekleriz.en bastakini ezeriz.
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId)/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var response = await _courseService.CreateAsync(courseCreateDto);
            return CreateActionResultInstance(response);

        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response); // butun methodlar icin response yaratmaya gerek kalmasin diye
            //shared altina topladik.Returnde herhangi bir tip belirtmeye gerek kalmadik.

        }
        #endregion
    }
}

