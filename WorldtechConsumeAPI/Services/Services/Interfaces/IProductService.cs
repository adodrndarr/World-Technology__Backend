using Presentation.ViewModels;
using System.Collections.Generic;


namespace Services
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> GetProductsFromApi(string apiUrl);
        List<ProductViewModel> GetProductsByName(string name);

        ProductViewModel GetProductById(int id);
        int GetNumberOfProducts();

        void AddNewProduct(ProductViewModel product);
        void RemoveProductById(int id);

        ProductViewModel GetMostExpensiveProduct();
        ProductViewModel GetCheapestProduct();
        List<string> DivideDescription(string description);

        List<ProductViewModel> GetComputers();
        List<ProductViewModel> GetGadgets();
        List<ProductViewModel> GetLaptops();

        void PopulateDbWithProducts();
        List<CommentVM> GetComments();
        void SaveComment(CommentVM commentVM);
        void DeleteAllComents();
    }
}