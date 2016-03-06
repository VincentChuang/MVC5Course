using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers {
    public class EFController : Controller {

        FabricsEntities db = new FabricsEntities();

        public ActionResult Index() {

            //新建立 Product 物件，不給 pkey，由 insert 完成後，取得 pkey
            var product = new Product() {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true
            };

            db.Product.Add(product);

            try {
                db.SaveChanges();   //寫入資料庫
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
            } catch (Exception ex2) {
                throw new Exception(ex2.Message);
            }

            var pkey = product.ProductId;   //找出 新增後 的 Primary ID

            var data = db.Product.Where(x => x.ProductId == pkey).ToList();

            return View(data);
        }

        public ActionResult Detail(int id) {
            //var data = db.Product.Find(id);
            var data = db.Product.FirstOrDefault(x => x.ProductId == id);
            return View(data);
        }


    }
}