using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MemberProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data) //Model Binding
        {
            return View();
        }


        public ActionResult MyOrder() {
            //58 利用 EnumHelper 輸出 enum 型別的屬性
            ViewData.Model = new MyOrderVM() {
                Id = 1,
                Name = "Will",
                Status = Status.C
            };

            return View();
        }
        public ActionResult MyOrderView() {
            ViewData.Model = new MyOrderVM() {
                Id = 1,
                Name = "Will",
                Status = Status.C
            };

            return View();
        }



    }
}