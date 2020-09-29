using Domain;
using Presentation.ViewModels;
using AutoMapper;


namespace Worldtech.Helpers.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<OrderDetail, CurrentOrderDetailVM>();
            CreateMap<CurrentOrderDetail, CurrentOrderDetailVM>().ReverseMap();
        }
    }
}
