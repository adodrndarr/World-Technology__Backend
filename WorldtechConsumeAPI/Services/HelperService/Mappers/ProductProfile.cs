using Domain;
using Presentation.ViewModels;
using AutoMapper;


namespace Worldtech.Helpers.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Comment, CommentVM>().ReverseMap();
        }
    }
}