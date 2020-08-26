using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockMVC.Models.Entity;

namespace StockMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        MvcDbStockEntities db = new MvcDbStockEntities();

        public ActionResult Index()
        {

            var values = db.Table_Product.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult NewProduct(Table_Product p1)
        {

            var cat = db.Table_Category.Where(m => m.categoryID == p1.Table_Category.categoryID).FirstOrDefault();
            p1.Table_Category = cat;
            db.Table_Product.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //List<Musteri> musteriList = new List<Musteri>() {
        //    new Musteri { mId = 1, musteriName = "Ali" },
        //    new Musteri { mId = 2, musteriName = "Veli" },
        //    new Musteri { mId = 3, musteriName = "Deli" }
        //};

        //List<Bayi> bayiList = new List<Bayi>()
        //{
        //    new Bayi{bId=1,mId=1,bayiName="Betbanca"},
        //    new Bayi{bId=2,mId=1,bayiName="Betbanca1"},
        //    new Bayi{bId=3,mId=2,bayiName="Betbanca2"},
        //    new Bayi{bId=4,mId=2,bayiName="Betbanca3"},
        //    new Bayi{bId=5,mId=3,bayiName="Betbanca4"},
        //};

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.Table_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.categoryName,
                                               Value = i.categoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;

            //ViewBag.customers = musteriList;
            //List<Bayi> bayiListNew = bayiList.Where(x => x.mId == 1).ToList();
            //ViewBag.locations = bayiListNew;
            return View();
        }

        public ActionResult RemoveProduct(int id)
        {
            var product = db.Table_Product.Find(id);
            db.Table_Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }

        [HttpPost]
        public ActionResult UpdateProduct(Table_Product p1)
        {
            var product = db.Table_Product.Find(p1.productID);
            product.productName = p1.productName;
            product.stock = p1.stock;
            product.price = p1.price;
            product.brand = p1.brand;
            product.productCategory = p1.productCategory;

            db.SaveChanges();
            return RedirectToAction("INDEX");
        }


        public ActionResult CallProduct(int id)
        {
            var product = db.Table_Product.Find(id);

            List<SelectListItem> values = (from i in db.Table_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.categoryName,
                                               Value = i.categoryID.ToString()
                                           }).ToList();

            ViewBag.Categories = values;

            return View("CallProduct", product);
        }



    }

    public class Musteri
    {
        public int mId { get; set; }
        public string musteriName { get; set; }
    }

    public class Bayi
    {
        public int bId { get; set; }
        public int mId { get; set; }
        public string bayiName { get; set; }
    }
}