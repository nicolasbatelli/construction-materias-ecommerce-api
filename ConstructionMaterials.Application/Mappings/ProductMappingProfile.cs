using AutoMapper;
using ConstructionMaterials.Application.Models;

namespace ConstructionMaterials.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Configure your mappings here
            CreateMap<Product, ProductDto>();
        }
    }
}