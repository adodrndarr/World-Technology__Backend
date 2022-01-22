using System.ComponentModel.DataAnnotations;


namespace Presentation.ViewModels
{
    public class LoginViewModel
    {
        const string MATCH_EMAIL_REGEX = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";

        [Required, StringLength(25, ErrorMessage = "Username must be less than 25 characters long.")]
        public string Username { get; set; }
        
        [Required, 
         DataType(DataType.Password), 
         MaxLength(100), MinLength(8, ErrorMessage = "The Password must be at least 8 characters long.")]
        public string Password { get; set; }
        
        public string RedirectToUrl { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address."),
         StringLength(50), 
         DataType(DataType.EmailAddress)]
        [RegularExpression(MATCH_EMAIL_REGEX, ErrorMessage = "Please provide a valid e-mail address format.")]
        public string Email { get; set; }
    }
}
