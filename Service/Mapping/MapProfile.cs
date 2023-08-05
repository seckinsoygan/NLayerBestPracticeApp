﻿using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
        }
    }
}
