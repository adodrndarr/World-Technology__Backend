using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Services;
using System.Threading.Tasks;


namespace Worldtech.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly ILoggerManager _logger;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                 ShoppingCartService shoppingCartService, ILoggerManager logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._shoppingCartService = shoppingCartService;
            this._logger = logger;
        }


        [HttpGet]
        public ViewResult Login(string redirectToUrl)
        {
            ViewData["Title"] = "Login";
            return View(new LoginViewModel() { RedirectToUrl = redirectToUrl });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ViewData["Title"] = "Login";

            if (!ModelState.IsValid) 
                return View(loginViewModel);

            IdentityUser user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user != null)
            {                
                var signInUser = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (signInUser.Succeeded)
                {
                    _logger.LogInfo($"User {loginViewModel.Username} signed in successfully.");
                    if (string.IsNullOrEmpty(loginViewModel.RedirectToUrl))
                        return RedirectToAction(nameof(ProductController.Index), nameof(Product));

                    return RedirectToAction(loginViewModel.RedirectToUrl);
                }
            }            

            ModelState.AddModelError("Password", "Invalid username or password, make sure you register before logging in.");           
            return View(loginViewModel);
        }
        [HttpGet]
        public ViewResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            ViewData["Title"] = "Register";
            
            if (ModelState.IsValid)
            {
                var userByName = await _userManager.FindByNameAsync(loginViewModel.Username);
                if (UserExists(userByName))
                {
                    ModelState.AddModelError("Username", $"The username {loginViewModel.Username} is already taken, please try using another one.");
                    return View(loginViewModel);
                }

                var userByEmail = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (UserExists(userByEmail))
                {
                    ModelState.AddModelError("Email", $"The address {loginViewModel.Email} has already been registered, please try using another one.");
                    return View(loginViewModel);
                }

                var user = new IdentityUser() { UserName = loginViewModel.Username, Email = loginViewModel.Email };
                var registerUser = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (registerUser.Succeeded)
                {
                    _logger.LogInfo($"User {loginViewModel.Username} registered successfully.");
                    return RedirectToAction(nameof(ProductController.Index), nameof(Product));
                }
            }

            ModelState.AddModelError("Password", "The Password must contain 1 capital letter, 1 number and 1 special character.");            
            return View(loginViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<RedirectToActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInfo("A user signed out.");
            return RedirectToAction(nameof(ProductController.Index), nameof(Product));
        }
        
        public bool UserExists(IdentityUser user)
        {
            if (user != null) return true;

            return false;
        }
    }
}
