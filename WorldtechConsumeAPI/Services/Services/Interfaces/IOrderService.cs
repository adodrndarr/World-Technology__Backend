using Domain;
using Presentation.ViewModels;
using System.Collections.Generic;


namespace Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderViewModel order);
        List<CurrentOrderDetailVM> GetCurrentOrderDetails();
    }
}
