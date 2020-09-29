namespace WorldtechApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductCategory Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
    public enum ProductCategory { Computer, Gadget, Laptop }
}
