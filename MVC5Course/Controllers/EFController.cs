using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers {
    public class EFController : Controller {

        public ActionResult Index() {

            var db = new FabricsEntities();
            db.Product.Add(
                new Product() {
                    ProductName = "BMW",
                    Price = 1,
                    Stock = 1,
                    Active = true
                }
            );

            try {
                db.SaveChanges();
            } catch (DbEntityValidationException ex) {
                string s = "";
                foreach (var e1 in ex.EntityValidationErrors) {
                    foreach (var e2 in e1.ValidationErrors) {
                        s += ";驗證欄位=" + e2.PropertyName + ",失敗訊息=" + e2.ErrorMessage;
                    }
                }
                if (s != "")
                    s = s.Substring(1);
                throw new Exception(s); //傳出自訂錯誤
            }

            var data = db.Product.ToList();

            return View(data);
        }


    }
}