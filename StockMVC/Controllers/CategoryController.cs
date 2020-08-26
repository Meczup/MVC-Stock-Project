using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockMVC.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StockMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MvcDbStockEntities db = new MvcDbStockEntities();//db MvcDbStockEntities sınıfından turetılen bır nesnedır.MvcDbStockEntities de model tutar.Modelin içinde de tablolar vardı tablolara ulaşmak ıcın db adında bır nesne olusturmam gerektı..
        public ActionResult Index(int page=1)
        {
            //var values = db.Table_Category.ToList();
            var values = db.Table_Category.ToList().ToPagedList(page,3);

            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {


            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(Table_Category p1)
        {
            if (!ModelState.IsValid)//dogrulama işlemi burda yapılmadıysa  NewCategory viewını bana gerı dondursun..
            {
                return View("NewCategory");
            }
            db.Table_Category.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult RemoveCategory(int id)
        {
            var category = db.Table_Category.Find(id);
            db.Table_Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }

        public ActionResult CallCategory(int id)
        {
            var category = db.Table_Category.Find(id);
            return View("CallCategory", category);

        }
        public ActionResult Update(Table_Category p1)
        {
            var category = db.Table_Category.Find(p1.categoryID);
            category.categoryName = p1.categoryName;
            db.SaveChanges();
            return RedirectToAction("INDEX");

        }

    }
}

