using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyMessagePro.DAL.Entities;
using MyMessagePro.Models;

namespace MyMessagePro.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pusername = await _userManager.FindByNameAsync(User.Identity.Name);
            MyProfileViewModel myProfile= new MyProfileViewModel();
            myProfile.username = pusername.UserName;
            myProfile.mail = pusername.Email;
            myProfile.city = pusername.city;
            
            return View(myProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Index(MyProfileViewModel myProfile)
        {
            var pusername = await _userManager.FindByNameAsync(User.Identity.Name);//sisteme otantike olan kişi
            if (myProfile.image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(myProfile.image.FileName);
                var imagename = Guid.NewGuid + extension;
                var savelocation = resource + "/wwwroot/memberimages/"+ imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await myProfile.image.CopyToAsync(stream);
                pusername.imageUrl = imagename;
            }
            if (!string.IsNullOrEmpty(myProfile.password))
            {
                pusername.PasswordHash = _userManager.PasswordHasher.HashPassword(pusername, myProfile.password);
            }
            pusername.UserName = myProfile.username;
            pusername.city = myProfile.city;
            //pusername.PasswordHash = _userManager.PasswordHasher.HashPassword(pusername, myProfile.password);
            var result = await _userManager.UpdateAsync(pusername);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            ModelState.AddModelError(string.Empty, "Kullanıcı profilini güncelleme başarısız.");
            return View();
        }
    }
}
