using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class OrderController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        public IHttpActionResult Payment()
        {
            //Customer user = Session["Customer"] as Customer;
            List<CartItem> ShopCart = Session["Cart"] as List<CartItem>;
            Order order = new Order();
            order.Id = db.Orders.ToArray().Count();
            order.Status = "Handling";
            order.Customer = 191;
            order.OrderDate = DateTime.Now;
            order.OderDue = DateTime.Now.AddDays(3);
            db.Orders.Add(order);
            foreach (CartItem item in ShopCart)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = db.Orders.ToArray().Count();
                orderDetail.Product = item.Id;
                orderDetail.Quantity = item.quantity;
                orderDetail.OrderId = order.Id;
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return Redirect("~/Home");
        }
    }
}
