using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        DbWatchShopEntities db = new DbWatchShopEntities();

        public ActionResult Index(Contact newContact)
        {
            ViewBag.Title = "Contact";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(string name, string email, string message)
        {
            Contact cmp = new Contact()
            {
                Id = db.Contacts.ToArray().Count(),
                Name = name,
                Email = email,
                Message = message
            };
            
         
            using (var client = new HttpClient())
            {
                //HTTP POST
                client.BaseAddress = new Uri("https://localhost:44380/api/contact");
                var rs = client.PostAsJsonAsync<Contact>("contact?name=" + name + "&email=" + email + "&message=" + message, cmp);
                rs.Wait();
                var re = rs.Result;
              

                if (re.IsSuccessStatusCode)
                {
                    ViewBag.Successful = "Gửi thành công";
                    return View("Index");
                }
            }
           
            return View(cmp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //su dung cho trang about

        public ActionResult RegisterNotify(string email)
        {
            string[] listC = email.Split('@');
            Contact cmp = new Contact()
            {
                Id = db.Contacts.ToArray().Count(),
                Name = listC[0],
                Email = email,
                Message = "Đăng Ký Nhận Thông Báo Từ WatchStore"
            };
            
            using (var client = new HttpClient())
            {
                //HTTP POST
                client.BaseAddress = new Uri("https://localhost:44380/api/contact");
                var rs = client.PostAsJsonAsync<Contact>("contact?email=" + email, cmp);
                rs.Wait();
                var re = rs.Result;

                if (re.IsSuccessStatusCode)
                {
                    return View("Index");

                }
            }
            return View(cmp);
        }
    }
}