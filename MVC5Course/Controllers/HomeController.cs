using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers {
    public class HomeController : BaseController {

        [紀錄Action的執行時間]                                 //自訂 ActionFilter
        [共用的ViewBag資料共享於部分HomeController動作方法]    //自訂 ActionFilter
        public ActionResult Index() {
            return View();
        }

        [紀錄Action的執行時間]                                 //自訂 ActionFilter
        [共用的ViewBag資料共享於部分HomeController動作方法]    //自訂 ActionFilter
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




        [HandleError(ExceptionType = typeof(ArgumentException), View = "Error_1")]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "Error_2")]
        public ActionResult ErrorTest(string e) {
            if (e == "1") {
                throw new Exception("Error 1");
            }
            if (e == "2") {
                throw new ArgumentException("Error 2");
            }
            return Content("No Error");
        }




    }
}