using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockMVC.Models.Entity;

namespace StockMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        MvcDbStockEntities db = new MvcDbStockEntities();

        public ActionResult Index(string p)
        {
            var values = from val in db.Table_Customer select val;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.customerName.Contains(p));
            }
            return View(values.ToList());
            //var values = db.Table_Customer.ToList();
            //return View(values);
        }
        [HttpPost]
        public ActionResult NewCustomer(Table_Customer c1)
        {

            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Table_Customer.Add(c1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {

            return View();
        }

        public ActionResult RemoveCustomer(int id)
        {
            var customer = db.Table_Customer.Find(id);
            db.Table_Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }
        public ActionResult UpdateCustomer(Table_Customer c1)
        {
            var customer = db.Table_Customer.Find(c1.customerID);
            customer.customerName = c1.customerName;
            customer.customerLname = c1.customerLname;
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }
        public ActionResult CallCustomer(int id)
        {
            var customer = db.Table_Customer.Find(id);
            return View("CallCustomer", customer);

        }
    }
}