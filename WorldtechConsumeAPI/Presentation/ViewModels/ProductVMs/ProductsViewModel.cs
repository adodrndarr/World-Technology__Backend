using System.Collections.Generic;


namespace Presentation.ViewModels
{
    public class ProductsViewModel
    {
        public List<ProductViewModel> Computers { get; set; } = new List<ProductViewModel>();
        public List<ProductViewModel> Gadgets { get; set; } = new List<ProductViewModel>();
        public List<ProductViewModel> Laptops { get; set; } = new List<ProductViewModel>();
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public List<CommentVM> Comments { get; set; }
        public CommentVM Comment { get; set; }
    }
}