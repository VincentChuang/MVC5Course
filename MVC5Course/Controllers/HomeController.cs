using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers {
    public class HomeController : BaseController {

        [紀錄Action的執行時間Attribut]
        [共用的ViewBag資料共享於部分HomeController動作方法Attribute]
        public ActionResult Index() {
            return View();
        }

        [紀錄Action的執行時間Attribut]
        [共用的ViewBag資料共享於部分HomeController動作方法Attribute]
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test() {
            return View();
        }

    }
}