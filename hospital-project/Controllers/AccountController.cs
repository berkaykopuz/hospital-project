using hospital_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hospital_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ILogger<AccountController> logger, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        bool isInRole = await _userManager.IsInRoleAsync(user, "");
                        if (isInRole)
                            return Redirect("/" + "Doctor");
                        else
                            return Redirect("/" + "Company");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or passwoord.");
            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.Name,
                Email = model.Email,
            };
            var result = await _userManager
                .CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager
                    .AddToRoleAsync(user, "Customer");

                if (roleResult.Succeeded)
                    return RedirectToAction("Login", new { ReturnUrl = "/" });

            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }
    }
}
