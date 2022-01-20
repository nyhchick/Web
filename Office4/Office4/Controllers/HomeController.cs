using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Office4.Models;

namespace Office4.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Product
            IEnumerable<Product> products = db.Products;
            // передаем все полученный объекты в динамическое свойство Product в ViewBag
            ViewBag.Products = products;
            // возвращаем представление
            return View();
        }

        public ActionResult Product(int id)
        {

            Product product = db.Products.Find(id);
            ViewBag.ThisProduct = product;
            return View();

        }


        public ActionResult ToBasket(int id)
        {
            Basket basket = new Basket();
            basket.ProductId = id;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Basket(int Total = 0)
        {
            IEnumerable<Basket> baskets = db.Baskets;
            List<Product> Items = new List<Product>();
            foreach (var Bas in baskets)
            {
                foreach (var item in db.Products)
                {
                    if (Bas.ProductId == item.Id)
                    {
                        Items.Add(item);
                        Total += item.Price;
                    }
                }
            }
            ViewBag.Total = Total;

            ViewBag.ThisBasket = Items;
            return View();
        }


        [HttpPost]
        public ActionResult ItemSearch(string name)
        {
            var allitems = db.Products.Where(a => a.Name.Contains(name)).ToList();
            if (allitems.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allitems);
        }



        public ActionResult Buy()
        {
            IEnumerable<Basket> basket = db.Baskets;
            List<Product> items = new List<Product>();
            foreach (var BS in basket)
            {
                foreach (var item in db.Products)
                {
                    if (BS.ProductId == item.Id)
                    {
                        items.Add(item);
                        db.Baskets.Remove(BS);
                        break;
                    }
                }
            }
            foreach (var i in items)
            {
                Order order = new Order();
                order.ProductId = i.Id;
                db.Orders.Add(order);
            }
            db.SaveChanges();
            return View();
        }
    }
}