using Microsoft.Web.Mvc;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers {
    public class ARController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult Index_PartialView() {
            return PartialView("Index");
        }

        public ActionResult ContentTest() {
            return Content("");
        }

        public ActionResult FileTest() {
            return File( Server.MapPath("~/Content/pic.png"),"image/png",
                "GoGoGo.png" ); //強迫檔案下載
        }

        //輸出 Json
        [AjaxOnly]  //需安裝 MVC Future 套件，主要判斷 XMLHttpRequest header
        public ActionResult JsonTest() {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;//為防止循環參考，由 Product 又捉 OrderLine
            var data = db.Product.Take(3);  //抓取三筆
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectTest() {
            //轉址到 /Product/Edit/1
            return RedirectToAction("Edit", "Product", new { id = 1 });
        }


    }
}