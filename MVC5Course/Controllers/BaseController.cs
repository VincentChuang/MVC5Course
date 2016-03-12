using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers {

    public abstract class BaseController : Controller {

        //private FabricsEntities db = new FabricsEntities();
        protected ProductRepository repo = RepositoryHelper.GetProductRepository();

        //共用 debug
        public ActionResult Debug() {
            return Content("DEBUG");
        }

        //若有 不合法 的 Action 即會被 HandleUnKnownAction 攔截
        protected override void HandleUnknownAction(string actionName) {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
        }

    }

}