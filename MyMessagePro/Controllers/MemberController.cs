using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMessagePro.DAL.Context;
using MyMessagePro.DAL.Entities;

namespace MyMessagePro.Controllers
{
    
    public class MemberController : Controller
    {
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;

        public MemberController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult myProfile()
        {
            return View();
        }
        public IActionResult myInbox()
        {
            var pusername = HttpContext.Session.GetString("Username");
            var values = c.UMessages.Where(x => x.receiverUsername == pusername).ToList();
            return View(values);
        }
        public IActionResult mySendbox()
        {
            var pusername = HttpContext.Session.GetString("Username");
            var values = c.UMessages.Where(x => x.senderUsername == pusername).ToList();
            return View(values);
        }
        public IActionResult myFriend()
        {
            var pusername = HttpContext.Session.GetString("Username");
            var values = c.Friendships.Where(x => x.friendSenderUsername == pusername).ToList();
            return View(values);
        }
    }
}
