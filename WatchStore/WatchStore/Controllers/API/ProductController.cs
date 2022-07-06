using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class ProductController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        
        public IHttpActionResult GetProductByBrand(string bid)
        {
            var products = db.Products.Where(p => p.Brand.Equals(bid));
            return Ok(products);
        }
        public IHttpActionResult GetProductByGender(string gen)
        {
            var products = db.Products.Where(p => p.Gender.Equals(gen)).OrderByDescending(p => p.CreateDate);
            return Ok(products);
        }
        public IHttpActionResult GetProductDetail(int pid)
        {
            Product pu = db.Products.Where(p => p.Id.Equals(pid)).FirstOrDefault();
            return Ok(pu);
        }

        public IHttpActionResult GetProductByBestSeller()
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.Import - p.Stock).Take(4).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByOnSale(float numSale)
        {
            IList<Product> products = db.Products.OrderByDescending(p =>p.Discount).Take(12).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByBestDeal(float deal)
        {
            var products = db.Products.OrderByDescending(p => p.Discount);
            return Ok(products);
        }
        public IHttpActionResult GetProductByRich(float rich)
        {
            IList<Product> products = (IList<Product>)db.Products.OrderByDescending(p => p.Price).ToList();
            return Ok(products);
        }

        // dang gap loi
        public IHttpActionResult GetProductByNewArrival(DateTime da)
        {
           
            IList<Product> products = db.Products.OrderByDescending(p => p.UpdateDate).OrderByDescending(p => p.CreateDate).Take(12).ToList();
            return Ok(products);

        }
        public IHttpActionResult GetProductByPopular(int popular)
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.Import).OrderByDescending(p => p.CreateDate).Take(12).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByOrigin(string origin)
        {
            var products = db.Products.Where(p => p.Origin.Equals(origin)).OrderByDescending(p => p.CreateDate);
            return Ok(products);
        }
        public IHttpActionResult GetProductByWaterproof(string waterproof)
        {
            var products = db.Products.Where(p => p.Waterproof.Equals(waterproof)).OrderByDescending(p => p.CreateDate);
            return Ok(products);
        }
        //CHUA LOAD 
        public IHttpActionResult GetProductByPrice(double priceFrom, double priceTo)
        {
            var products = db.Products.Where(p => p.Price >= priceFrom & p.Price <= priceTo).OrderBy(p => p.Price-(p.Price * p.Discount)/100);
            return Ok(products);
        }
        public IHttpActionResult GetProductByName(string txtName)
        {
            var products = db.Products.Where(p => p.Name.Contains(txtName)).OrderByDescending(p => p.CreateDate);
            return Ok(products);
        }




    }
}
