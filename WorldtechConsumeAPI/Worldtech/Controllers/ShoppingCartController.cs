using System.Collections.Generic;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.HelperService.Helpers;
using Worldtech.Models;


namespace Worldtech.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCart;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public ShoppingCartController(IProductService productService, ShoppingCartService shoppingCart,
                                      IMapper mapper, ILoggerManager logger)
        {
            this._shoppingCart = shoppingCart;
            this._productService = productService;
            this._mapper = mapper;
            this._logger = logger;
        }


        [HttpGet]
        public IActionResult ShoppingCartIndex()
        {
            ViewData["Title"] = "Shopping Cart";
            if (_shoppingCart.GetNumberOfItems() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty, add some products first!");
                return RedirectToAction(nameof(ProductController.Index), nameof(Product));
            }

            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartVM = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalPrice(),
                NumberOfItems = _shoppingCart.GetNumberOfItems()
            };            

            return View(shoppingCartVM);
        }

        [HttpGet]
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var productVM = _productService.GetProductById(productId);
            
            if (!HelperService.AProductExists(productVM)) 
                RedirectToAction(nameof(ProductController.ProductNotFound), nameof(Product), new { message = "" });
            else
            {
                var productToAdd = _mapper.Map<Product>(productVM);
                _shoppingCart.AddToCart(productToAdd, 1);
                _logger.LogInfo($"A product with id: {productId} has been added to the shopping cart.");
            }
            
            return RedirectToAction(nameof(ShoppingCartIndex));
        }

        [HttpGet]
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var productVM = _productService.GetProductById(productId);
            if (!HelperService.AProductExists(productVM))
                RedirectToAction(nameof(ProductController.ProductNotFound), nameof(Product), new { message = "" });
            else
            {
                var productToRemove = _mapper.Map<Product>(productVM);
                _shoppingCart.RemoveFromCart(productToRemove);
                _logger.LogInfo($"A product with id: {productId} has been removed from the shopping cart.");
            }

            if (_shoppingCart.GetNumberOfItems() == 0) 
                return RedirectToAction(nameof(ProductController.Index), nameof(Product));

            return RedirectToAction(nameof(ShoppingCartIndex));
        }
    }
}
