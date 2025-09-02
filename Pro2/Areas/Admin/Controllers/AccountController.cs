using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pro2.View_Models;

namespace Pro2.Areas.Admin.Controllers
{

    [Area("Admin")]


    public class AccountController : Controller
    {
        UserManager<IdentityUser> UserManager;
        SignInManager<IdentityUser> signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // عرض الصفحة مرة أخرى مع الأخطاء
            }

            if (model.Password != model.PasswordConfirmation)
            {
                ModelState.AddModelError("PasswordConfirmation", "كلمة المرور وتأكيدها غير متطابقين.");
                return View(model);
            }

            var newUser = new IdentityUser
            {
                UserName = model.UserName ?? "", // تجنب null
                NormalizedUserName = model.UserName?.ToUpper() ?? "",
                Email = model.Email ?? "",
                NormalizedEmail = model.Email?.ToUpper() ?? ""
            };

            var result = await UserManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model); // إذا فشل الإنشاء
        }
    }
}

