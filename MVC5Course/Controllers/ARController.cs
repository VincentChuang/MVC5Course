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


    }
}