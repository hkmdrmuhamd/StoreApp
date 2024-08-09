using AutoMapper;
using StoreApp.Data.Concreate;

namespace StoreApp.Web.Models;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
}