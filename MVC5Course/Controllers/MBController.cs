using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers {
    public class MBController : Controller {


        public ActionResult Index() {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string Name,DateTime Birthday) {
        //    return Content("Name=" + Name + ",Birthday=" + Birthday);
        //}
        //使用 FormCollection 接資料
        //[HttpPost]
        //public ActionResult Index(FormCollection form) {
        //    return Content("Name=" + form["Name"] + ",Birthday=" + form["Birthday"]);
        //}
        //複雜型別 Binding
        [HttpPost]
        public ActionResult Index(MemberViewModel data) {
            return Content("Name=" + data.Name + ",Birthday=" + data.Birthday);
        }




    }
}