using System;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.BaseController
{
	public class CustomBaseController : ControllerBase // aspnetcore.mvc altinda bulunuyor.
	{
		public IActionResult CreateActionResultInstance<T>(Response<T> response)
		{
			return new ObjectResult(response) //return notfound,bad request,404 vs donmeye gerek kalmiyor.
			{
				StatusCode = response.StatusCode
			};
		}
	}
}

