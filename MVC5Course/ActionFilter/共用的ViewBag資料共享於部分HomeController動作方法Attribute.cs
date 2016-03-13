using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC5Course.Controllers {

    public class 共用的ViewBag資料共享於部分HomeController動作方法Attribute : ActionFilterAttribute {

        //在執行 Action 前
        public override void OnActionExecuting(ActionExecutingContext filterContext) {

            //在 filter 前 寫入 ViewBag，讓 Action 可共用
            filterContext.Controller.ViewBag.Message = "Your application description page.";

            base.OnActionExecuting(filterContext);
        }

        //在執行 Action 後
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            base.OnActionExecuted(filterContext);
        }

    }

}
