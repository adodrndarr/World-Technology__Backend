using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class OrderViewModel
    {        
        public List<CurrentOrderDetailVM> OrderDetails { get; set; } = new List<CurrentOrderDetailVM>() { };
        
        [Required(ErrorMessage = "Please enter your first name."), 
         Display(Name = "First name"), StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name."), 
         Display(Name = "Last name"), StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your country."), StringLength(30, MinimumLength = 2)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address."), 
         StringLength(50), DataType(DataType.EmailAddress)]        
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", 
            ErrorMessage = "Please provide a valid e-mail address format.")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
    }
}
