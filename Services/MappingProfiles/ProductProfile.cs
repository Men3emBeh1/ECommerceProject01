using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>()
                .ForMember(p => p.BrandName, r => r.MapFrom(d => d.ProductBrand.Name))
                .ForMember(p => p.TypeName, r => r.MapFrom(t => t.ProductType.Name))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<ProductType, TypeResultDto>();
        }
    }
}
