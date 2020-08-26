using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockMVC.Models.Entity;

namespace StockMVC.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(Table_Sales p)
        {
            db.Table_Sales.Add(p);
            db.SaveChanges();
            return View("Index");

        }

    }
}