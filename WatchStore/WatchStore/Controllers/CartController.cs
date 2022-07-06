using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        DbWatchShopEntities db = new DbWatchShopEntities();
        public ActionResult Index()
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            return View(cart);
        }
        public RedirectToRouteResult AddToCart(int pid)
        {
            if (Session["cart"] == null) 
            {
                Session["cart"] = new List<CartItem>(); 
            }

            List<CartItem> cart = Session["cart"] as List<CartItem>;

            if (cart.FirstOrDefault(m => m.Id == pid) == null) 
            {
                // tim sp theo sanPhamID
                Product sp = db.Products.Find(pid);
                CartItem newItem = new CartItem()
                {
                    Id = pid,
                    Name = sp.Name,
                    quantity = 1,
                    Avatar = sp.Avatar,
                    Gender = sp.Gender,
                    unitPrice = ((int)(sp.Price - ((sp.Price * sp.Discount) / 100)))
                };  

                cart.Add(newItem);  
            }
            else
            {
                CartItem cardItem = cart.FirstOrDefault(m => m.Id == pid);
                cardItem.quantity++;
            }

            return RedirectToAction("Index", "Cart", new { id = pid });
        }
        public RedirectToRouteResult ModifyQuantity(int pid, int newQuantity)
        {
            // tìm carditem muon sua
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem itemSua = cart.FirstOrDefault(m => m.Id == pid);
            if (itemSua != null)
            {
                itemSua.quantity = newQuantity;
            }
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult RemoveProduct(int pid)
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem itemXoa = cart.FirstOrDefault(m => m.Id == pid);
            if (itemXoa != null)
            {
                cart.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
       

    }
}