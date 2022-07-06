using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class ContactController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetContacts()
        {
            IList<Contact> contacts = db.Contacts.OrderByDescending(c => c.Id).ToList();
            return Ok(contacts);
        }
        public IHttpActionResult PostContacts(string name, string email, string message)
        {          
                db.Contacts.Add(new Contact()
                {
                    Id = db.Contacts.ToArray().Count(),
                    Name = name,
                    Email = email,
                    Message = message
                });
                db.SaveChanges();

           
            return Ok();
        }

        // post contact aboutpage
        public IHttpActionResult PostContacts(string email)
        {
            string[] listC = email.Split('@');
            db.Contacts.Add(new Contact()
            {
                Id = db.Contacts.ToArray().Count(),
                Name =  listC[0],
                Email = email,
                Message = "Đăng Ký Nhận Thông Báo Từ WatchStore"
            });
            db.SaveChanges();
            return Ok();
        }
    }
}
