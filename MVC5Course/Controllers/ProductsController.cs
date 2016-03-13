using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        //private ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: Products
        public ActionResult Index()
        {
            var data = repo.All().Take(5);
            return View(data);
            //return View(db.Product.ToList());
        }

        [HttpPost]
        public ActionResult Index(IList<Products批次更新ViewModel> productsX) { //額外宣告 ViewModel 並進行 驗證

            if (ModelState.IsValid) {
                foreach (var item in productsX) {
                    var product = repo.Find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }
                repo.UnitOfWork.Commit();
            }

            return View(repo.All().Take(5));
        }



        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();

                //db.Product.Add(product);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = repo.Find(id.Value);

            //Product product = db.Product.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product) {
        public ActionResult Edit(int id , FormCollection form) {

            Product product = repo.Find(id);

            //32 練習複雜模型繫結 ( 使用 TryUpdateModel 做延遲驗證 )
            //使用 TryUpdateModel 做延遲驗證
            if (TryUpdateModel<Product>(product, new string[] {
                "ProductId", "ProductName", "Price", "Active", "Stock" })) {    
                    repo.UnitOfWork.Commit();
                    TempData["ShowMsg"] = "商品編輯成功";
            }

            //if (ModelState.IsValid) {
            //    //var db = (FabricsEntities)repo.UnitOfWork.Context;
            //    //db.Entry(product).State = EntityState.Modified;
            //    //db.SaveChanges();
            //    TempData["ShowMsg"] = "商品編輯成功";
            //    return RedirectToAction("Index");
            //}

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            product.isDelete = true;
            repo.UnitOfWork.Commit();

            //Product product = db.Product.Find(id);
            ////db.Product.Remove(product);
            //product.isDelete = true;
            //db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
