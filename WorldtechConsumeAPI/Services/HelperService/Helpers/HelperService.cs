using Presentation.ViewModels;
using System.Collections.Generic;


namespace Services.HelperService.Helpers
{
    public static class HelperService
    {        
        public static bool ContainsSearchWord(string searchWord, string targetString)
        {
            if (searchWord != null && targetString != null)
            {
                string searched = searchWord.ToLower();
                string target = targetString.ToLower();

                if (target.Contains(searched)) return true;
            }

            return false;
        }

        public static bool AProductExists(ProductViewModel product)
        {
            if (product != null) return true;

            return false;
        }

        public static bool AProductExists(List<ProductViewModel> products)
        {
            if (products.Count > 0) return true;

            return false;
        }            
        
        public static List<ProductViewModel> GetProductsWithInputTerm(string searchTerm, List<ProductViewModel> productsVMs)
        {
            return productsVMs.FindAll(product =>
                                ContainsSearchWord(searchTerm, product.Name) ||
                                ContainsSearchWord(searchTerm, product.Description));
        }        

        public static bool IsStringOk(string inputString)
        {
            if (inputString == null) return false;
            if (inputString.Length < 10 || inputString.Length > 150) return false;

            return true;
        }
    }
}
