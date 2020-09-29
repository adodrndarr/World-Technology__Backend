namespace Presentation.ViewModels
{
    public class CurrentOrderDetailVM
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual OrderViewModel Order { get; set; }
    }
}