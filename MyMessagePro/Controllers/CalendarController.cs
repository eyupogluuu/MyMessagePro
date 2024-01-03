using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyMessagePro.Controllers
{
    public class CalendarController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
