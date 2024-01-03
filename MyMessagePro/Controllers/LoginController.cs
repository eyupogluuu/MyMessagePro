using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMessagePro.DAL.Context;
using MyMessagePro.DAL.Entities;
using MyMessagePro.Models;

namespace MyMessagePro.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel u)
        {
            
            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(u.username, u.password, false,true);
                
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(u.username);
                    if (user != null)
                    {
                        // Kullanıcının soyadını Session içinde sakla
                        HttpContext.Session.SetString("Username", user.UserName);
                        ViewBag.username = user.UserName;
                    }


                        return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register(UserRegisterViewModel u)
        {
            AppUser appUser = new AppUser()
            {
                UserName = u.username,
                Email = u.mail
            };
            if (u.password == u.confirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, u.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }


            return View(u);
        }
        public async Task<IActionResult> logout()
        {
            // Kullanıcının oturumunu sonlandır
            await _signInManager.SignOutAsync();

            // Session'daki kullanıcı adını temizle
            HttpContext.Session.Remove("Username");

            // Çıkış yaptıktan sonra giriş sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }

    }
}
