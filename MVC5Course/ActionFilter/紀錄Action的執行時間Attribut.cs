using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC5Course.Controllers {

    public class 紀錄Action的執行時間Attribute : ActionFilterAttribute {

        //在執行 Action 前
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            // 紀錄開始時間
            base.OnActionExecuting(filterContext);
        }

        //在執行 Action 後
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            // 紀錄結束時間

            // 計算執行時間
            TimeSpan exectuionTime = TimeSpan.FromHours(1);
            filterContext.Controller.ViewBag.執行時間 = exectuionTime;  //回傳記錄時間

            base.OnActionExecuted(filterContext);
        }

    }

}
