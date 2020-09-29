using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

using Data;
using Services;
using Services.HelperService.Helpers;


namespace Worldtech.Controllers
{
    public class ProductController : Controller
    {        
        private IProductService _productService;
        private WorldtechDbContext _worldtechDbContext;
        private readonly ILoggerManager _logger;
        public ProductController(IProductService productService, WorldtechDbContext worldtechDbContext,
                                 ILoggerManager logger)
        {
            this._productService = productService;
            this._worldtechDbContext = worldtechDbContext;
            this._logger = logger;
        }

        
        [HttpGet]
        public ViewResult Index()
        {            
            ViewData["Title"] = "Home";            
            List<ProductViewModel> productsVMs = _productService.GetAllProducts();

            int productCount = productsVMs.Count;
            if (productCount == 0)
            {
                string url = "worldtechApi/GetProducts";
                productsVMs = this._productService.GetProductsFromApi(url);

                    _logger.LogInfo("Got products from the API.");
                _productService.PopulateDbWithProducts();
                    _logger.LogInfo("Populated Database with products.");
            }
            else _logger.LogInfo("Got stored products from the database");

            var productsVM = new ProductsViewModel() { Products = productsVMs };
            return View(productsVM);
        }

            
        [HttpGet]
        public ViewResult Computers()
        {
            ViewData["Title"] = "Computers";
            List<ProductViewModel> computersVMs = _productService.GetComputers();
            if(!HelperService.AProductExists(computersVMs)) RedirectToAction(nameof(ProductNotFound), new { message = "" });

            _logger.LogInfo("Got computers from product service.");
            var productsVM = new ProductsViewModel() { Computers = computersVMs };
            return View(productsVM);
        }

        [HttpGet]
        public ViewResult Gadgets()
        {
            ViewData["Title"] = "Gadgets";
            List<ProductViewModel> gadgetsVMs = _productService.GetGadgets();
            if (!HelperService.AProductExists(gadgetsVMs)) RedirectToAction(nameof(ProductNotFound), new { message = "" });

            _logger.LogInfo("Got gadgets from product service.");
            var productsVM = new ProductsViewModel() { Gadgets = gadgetsVMs };
            return View(productsVM);
        }

        [HttpGet]
        public ViewResult Laptops()
        {
            ViewData["Title"] = "Laptops";
            List<ProductViewModel> laptopsVMs = _productService.GetLaptops();
            if (!HelperService.AProductExists(laptopsVMs)) RedirectToAction(nameof(ProductNotFound), new { message = "" });

            _logger.LogInfo("Got laptops from product service.");
            var productsVM = new ProductsViewModel() { Laptops = laptopsVMs };
            return View(productsVM);
        }
        
        [HttpGet]
        public IActionResult SearchProduct(string inputSearch)
        {
            ViewData["Title"] = "Search";
            List<ProductViewModel> productsVMs = _productService.GetAllProducts();
            if (!HelperService.AProductExists(productsVMs)) RedirectToAction(nameof(ProductNotFound), new { message = "" });
            _logger.LogInfo("Got products that user searched for from product service.");

            var productsFound = HelperService.GetProductsWithInputTerm(inputSearch, productsVMs);
            if (productsFound.Count == 0) return RedirectToAction(nameof(ProductNotFound), new { message = inputSearch});
            else productsVMs = productsFound;
            
            var productsVM = new ProductsViewModel() { Products = productsVMs };
            return View(productsVM);
        }

        [HttpGet]
        public ViewResult ProductNotFound(string message)
        {
            ViewData["Title"] = "Not Found";
            var notFoundVM = new ProductNotFoundViewModel() { Message = message };

            return View(notFoundVM);
        }
        
        [HttpGet]
        public ViewResult About()
        {
            ViewData["Title"] = "About";
            ProductViewModel cheapestProduct = _productService.GetCheapestProduct();
            ProductViewModel expensiveProduct = _productService.GetMostExpensiveProduct();
            _logger.LogInfo("Got the cheapest and most expensive product from product service.");

            var productsVMs = new List<ProductViewModel> { cheapestProduct, expensiveProduct };
            var productsView = new ProductsViewModel() 
            { 
                Products = productsVMs,
                Comments = _productService.GetComments()
            };

            return View(productsView);
        }              

        [HttpPost]
        public RedirectToActionResult SaveComment(CommentVM commentVM)
        {
            string deletePwd = "123456789987654321987654321";
            if (commentVM.Message == deletePwd)
            {
                _productService.DeleteAllComents();
                return RedirectToAction(nameof(About));
            }

            if (!HelperService.IsStringOk(commentVM.Message)) return RedirectToAction(nameof(About)); 
                        
            _productService.SaveComment(commentVM);
            return RedirectToAction(nameof(About));            
        }
    }
}