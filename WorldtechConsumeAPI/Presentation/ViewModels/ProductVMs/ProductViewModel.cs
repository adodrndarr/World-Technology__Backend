using Domain;
using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public ProductCategory Category { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}