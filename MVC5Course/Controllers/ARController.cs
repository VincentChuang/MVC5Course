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

        public ActionResult JsonTest() {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;//為解決循環參考
            var data = db.Product.FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}