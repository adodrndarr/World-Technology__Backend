using Services;


namespace Worldtech.Models
{
    public class ShoppingCartViewModel
    {        
        public ShoppingCartService ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int NumberOfItems { get; set; }
    }
}