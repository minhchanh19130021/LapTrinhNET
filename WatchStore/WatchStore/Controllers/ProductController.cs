using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()

        {
            ViewBag.Title = "Product";
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Brand(string bid,int ? page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?bid=" + bid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Gender(String gen, int ? page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?gen=" + gen);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(string pid)
        {
            Product p = GetDetail(pid);
            IEnumerable<Product> products = GetProductByBestSeller();
            IEnumerable<Image> imgs = GetImages(pid);
            SharedProductDetail spd = new SharedProductDetail(p, products, imgs);
            return View(spd);
        }
        public Product GetDetail(string pid)
        {
            Product pu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?pid=" + pid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    pu = readRe.Result;
                }

            }
            return pu;
        }
        public IEnumerable<Product> GetProductByBestSeller()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return products;
        }
        public IEnumerable<Image> GetImages(string pid)
        {
            IEnumerable<Image> imgs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("image?pid" + pid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Image>>();
                    readRe.Wait();
                    imgs = readRe.Result;
                }

            }
            return imgs;
        }
        public ActionResult BestDeal(int?page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?deal=5");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Rich(int ? page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?rich=5");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Origin(string origin,int ? page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?origin=" + origin);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Waterproof(string waterproof, int ? page)
        {
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?waterproof=" + waterproof);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Price(double priceFrom,double priceTo,int?page)
        {
            ViewBag.priceF = priceFrom;
            ViewBag.priceT = priceTo;
            IEnumerable<Product> products = null;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?priceFrom=" + priceFrom + "&priceTo=" + priceTo);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }
            }
            return View(products.ToPagedList(pageNumber, pageSize));
        }
      
        public ActionResult Search(string txtName,int ? page)
        {
            IEnumerable<Product> products = null;
            ViewBag.textSearch = txtName;
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?txtName=" + txtName);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }
                

            }

            return View(products.ToPagedList(pageNumber, pageSize));
        }
       
    }
}