using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldtechApi.Models;
using WorldtechApi.Services;


namespace WorldtechApi.Controllers
{
    [Route("worldtechApi/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        
        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productService.GetProducts();
            if (products.Count == 0) 
                return NotFound();

            return products;
        }

    }
}
