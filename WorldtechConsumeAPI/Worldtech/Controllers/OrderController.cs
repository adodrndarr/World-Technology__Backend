using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Presentation.ViewModels;
using Services;
using System.Collections.Generic;


namespace Worldtech.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCartService _shoppingCart;
        private readonly IOrderService _orderService;
        private readonly ILoggerManager _logger;
        public OrderController(ShoppingCartService shoppingCart, IOrderService orderService, 
                               ILoggerManager logger)
        {
            this._shoppingCart = shoppingCart;
            this._orderService = orderService;
            this._logger = logger;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            ViewData["Title"] = "Checkout";
            if (_shoppingCart.GetNumberOfItems() == 0)
            {
                ModelState.AddModelError("Email", "Your shopping cart is empty, add some products first!");                
                return RedirectToAction(nameof(ProductController.Index), nameof(Product));
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(OrderViewModel order)
        {
            ViewData["Title"] = "Checkout";

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (ModelState.IsValid)
            {
                order.OrderTotal = _shoppingCart.GetTotalPrice();                
                _orderService.CreateOrder(order);
                
                TempData["OrderDetails"] = JsonConvert.SerializeObject(_orderService.GetCurrentOrderDetails());
                _logger.LogInfo($"An order has been created by {order.FirstName}.");

                _shoppingCart.ClearCart();
                return RedirectToAction(nameof(CheckoutComplete), order);
            }

            return View(order);
        }

        [HttpGet]
        public IActionResult CheckoutComplete(OrderViewModel order)
        {
            ViewData["Title"] = "Order completed";

            var currentOrderDetails = TempData["OrderDetails"];
            var orderDetails = new List<CurrentOrderDetailVM>();

            if (currentOrderDetails != null)
                orderDetails = JsonConvert.DeserializeObject<List<CurrentOrderDetailVM>>(currentOrderDetails.ToString());

            if (orderDetails.Count == 0) return RedirectToAction(nameof(ProductController.Index), nameof(Product));

            order.OrderDetails = orderDetails;
            return View(order);
        }
    }
}