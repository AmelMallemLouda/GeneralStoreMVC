using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {

        //We are adding a view for Transactions, and we need to tell the application  how to connect to the database
        // Add the application DB Context (link to the database)
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }
        public bool CreateTransaction(Customer customer, Product product,Transaction transaction)
        {
            var entity =
                new Transaction()
                {
                   
                   CustomerId=customer.CustomerId,
                   ProductId=product.ProductId,
                    DateOfTransaction = DateTime.Now,
                    Price=transaction.Price

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get: Transaction
        public ActionResult Create()
        {
            return View();
        }
        // POST: TRANSACTION
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");//RedirectToAction tells ASP.NET MVC to respond with a Browser redirect to a different action instead of rendering HTML. So, here, if we successfully add the new Transaction, then we should return to the Index view
            }
            //You can use View when you just want the browser to render HTML. You have to use RedirectToAction when you want to call another, different, command.
            return View(transaction);//tells MVC to generate HTML to be displayed and sends it to the browser
        }



    }
}