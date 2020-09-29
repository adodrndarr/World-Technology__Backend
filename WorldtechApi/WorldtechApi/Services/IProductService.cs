using System.Collections.Generic;
using WorldtechApi.Models;


namespace WorldtechApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
