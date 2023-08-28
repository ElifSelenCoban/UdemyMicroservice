using System;
using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mapping
{
	public class GeneralMapping:Profile //Profile automapperdan geliyor
	{
		public GeneralMapping()
		{
			CreateMap<Course, CourseDto>().ReverseMap(); //<source=entity,destination=dto>
            CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
        }

	}
}

