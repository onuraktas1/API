﻿using ApiProject.WebApi.Dtos.FeatureDtos;
using ApiProject.WebApi.Dtos.MessageDtos;
using ApiProject.WebApi.Dtos.ProductDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;

namespace ApiProject.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            //CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z=>z.Category.Name)).ReverseMap();
        }
    }
}
