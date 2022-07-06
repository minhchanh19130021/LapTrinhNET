using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        DbWatchShopEntities db = new DbWatchShopEntities();
        public ActionResult Index()
        {
           
            //if (Session["Customer"] != null)
            //    return Redirect("~/User/Login");
            return View();
        }
    }
}