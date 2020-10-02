using AutoMapper;
using Data.Repositories;
using Domain;
using Presentation.ViewModels;
using System.Collections.Generic;


namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingCartService _shoppingCart;
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<OrderDetail> _orderDetailRepo;
        private readonly IRepository<CurrentOrderDetail> _currentOrderDetailRepo;

        public OrderService(ShoppingCartService shoppingCart,
                            IMapper mapper, IRepository<Order> orderRepository,
                            IRepository<OrderDetail> orderDetailRepository,
                            IRepository<CurrentOrderDetail> currentOrderDetailRepository)
        {
            this._shoppingCart = shoppingCart;
            this._mapper = mapper;
            this._orderRepo = orderRepository;
            this._orderDetailRepo = orderDetailRepository;
            this._currentOrderDetailRepo = currentOrderDetailRepository;
        }


        public void CreateOrder(OrderViewModel orderVM)
        {
            var order = _mapper.Map<Order>(orderVM);
            _orderRepo.Insert(order);
            
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;            
            foreach (var cartItem in shoppingCartItems)
            {
                var orderDetail = OrderDetailMapper.ToOrderDetail(order, cartItem);
                _orderDetailRepo.Insert(orderDetail);
                
                var currentOrderDetailVM = _mapper.Map<CurrentOrderDetailVM>(orderDetail);
                var currentOrderDetail = _mapper.Map<CurrentOrderDetail>(currentOrderDetailVM);
                _currentOrderDetailRepo.Insert(currentOrderDetail);                
            }

            _orderRepo.Save();
            _orderDetailRepo.Save();
            _currentOrderDetailRepo.Save();
        }

        public List<CurrentOrderDetailVM> GetCurrentOrderDetails()
        {
            var currentOrderDetails = _currentOrderDetailRepo.GetAll();
            var currentOrderDetailsVMs = _mapper.Map<List<CurrentOrderDetailVM>>(currentOrderDetails);

            return currentOrderDetailsVMs;
        }        
    }
}