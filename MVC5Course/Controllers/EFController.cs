using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

using System.Data.Entity;

namespace MVC5Course.Controllers {
    public class EFController : Controller {

        FabricsEntities db = new FabricsEntities();

        public ActionResult Index(bool? isActivity, string keyWord) {

            //新建立 Product 物件，不給 pkey，由 insert 完成後，取得 pkey
            //var product = new Product() {
            //    ProductName = "BMW",
            //    Price = 2,
            //    Stock = 1,
            //    Active = true
            //};
            //db.Product.Add(product);
            //
            //try {
            //    db.SaveChanges();   //寫入資料庫
            //} catch (DbEntityValidationException ex) {
            //    string s = "";
            //    foreach (var e1 in ex.EntityValidationErrors) {
            //        foreach (var e2 in e1.ValidationErrors) {
            //            s += ";驗證欄位=" + e2.PropertyName + ",失敗訊息=" + e2.ErrorMessage;
            //        }
            //    }
            //    if (s != "")
            //        s = s.Substring(1);
            //    throw new Exception(s); //傳出自訂錯誤
            //} catch (Exception ex2) {
            //    throw new Exception(ex2.Message);
            //}
            //var pkey = product.ProductId;   //找出 新增後 的 Primary ID
            ////var data = db.Product.Where(x => x.ProductId == pkey).ToList();

            //var data = db.Product.OrderByDescending(x => x.ProductId).Take(5);  //取5筆記錄

            //foreach (var x in data) {
            //    x.Price += 1;   //修改 Product 價格
            //}
            //db.SaveChanges();   //回寫資料庫

            //db.Product.find()
            //db.OrderLine.RemoveRange(product.OrderLine);

            var data = db.Product.OrderByDescending(x => x.ProductId).AsQueryable();
            if (isActivity.HasValue) {
                data = data.Where(x => x.Active.HasValue ? x.Active == isActivity : false);
            }
            if (!String.IsNullOrEmpty(keyWord)) {
                data = data.Where(x=>x.ProductName.Contains(keyWord));
            }
            foreach (var x in data) {
                x.Price += 1;   //修改 Product 價格
            }
            SaveChanges();   //回寫資料庫

            return View(data);
        }

        public void SaveChanges(){
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
            }
            //catch (Exception ex2) {
            //    throw new Exception(ex2.Message);
            //}
        }

        public ActionResult Detail(int id) {
            //var data = db.Product.Find(id);   //取單筆資料
            var data = db.Product.FirstOrDefault(x => x.ProductId == id);   //取單筆資料
            return View(data);
        }

        public ActionResult Delete(int id) {
            var item = db.Product.Find(id);
            //db.OrderLine.RemoveRange(item.OrderLine);   //先刪除 OrderLine 資料，以防止外鍵阻擋
            db.Product.Remove(item);    //刪除資料
            SaveChanges();

            return RedirectToAction("Index");   //回到 Index Action
        }


        //測試 
        //public ActionResult ViewModify() {
        //    var v = db.vwClientOrder.FirstOrDefault();
        //    v.firstname = "測試1";
        //    v.lastname = "測試2";
        //    db.SaveChanges();
        //    return View();
        //}


        public ActionResult QueryPlan() {

            //寫法一
            var data = db.Product
                .OrderBy(x => x.ProductId)
                .AsQueryable();

            //寫法二：查詢計劃，弱型別
            //var data = db.Product
            //    .Include("OrderLine")
            //    .OrderBy(x => x.ProductId)
            //    .AsQueryable();

            //寫法三：查詢計劃，強型別
            //var data = db.Product
            //    .Include(x => x.OrderLine)
            //    .OrderBy(x => x.ProductId)
            //    .AsQueryable();

            //寫法四：使用 SqlQuery 查詢，但導覽屬性會失效，View 的 item.OrderLine.Count() 會取得 0
            //var data = db.Database.SqlQuery<Product>(@"
            //    select *
            //    from dbo.Product p
            //    left join dbo.OrderLine o on p.ProductId=o.ProductId
            //");

            return View(data);
        }



    }
}