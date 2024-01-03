using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMessagePro.DAL.Context;
using MyMessagePro.DAL.Entities;

namespace MyMessagePro.Controllers
{
 
    public class UmessageController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult addMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addMessage(UMessage umes, string button)
        {
            var pusername = HttpContext.Session.GetString("Username");

            if (button == "draft")
            {

                umes.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                umes.senderUsername = pusername;
                umes.draft = true;
                c.UMessages.Add(umes);
                c.SaveChanges();
                return RedirectToAction("draftList","Umessage");


            }
            else if (button == "save")
            {
                umes.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                umes.senderUsername = pusername;
                umes.draft= false;
                umes.status = true;
                c.UMessages.Add(umes);
                c.SaveChanges();
                return RedirectToAction("mySendbox", "Member");
            }
            else if (button == "exit")
            {
                return RedirectToAction("myInbox", "Member");
            }


            return View();
        }
        public IActionResult draftList()
        {
            //string userEmail = (string)Session["WriterMail"];
            //var sendList = mm.GetMessageSendbox(userEmail);
            //var draftList = sendList.FindAll(x => x.isDraft == true);
            //return View(draftList);

            var pusername = HttpContext.Session.GetString("Username");
            var sendlist = c.UMessages.Where(x => x.senderUsername == pusername).ToList();
            var draftlist = sendlist.FindAll(x => x.draft == true);
            return View(draftlist);
        }
        public IActionResult messageDetail(int id)
        {
            var values = c.UMessages.Find(id);
            return View(values);
        }
        public IActionResult messageDelete(int id)
        {
            var values = c.UMessages.Find(id);// önce silinecek kategoriyi bul
            c.Remove(values);
            c.SaveChanges();
            return RedirectToAction("myInbox","Member");
        }
    }
}
