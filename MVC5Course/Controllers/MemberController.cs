using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {

        [AllowAnonymous]    //排除不驗證
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]    //排除不驗證
        public ActionResult Login(LoginViewModel login) {
            //驗證成功
            if (CheckLogin(login.Email, login.Password)) {
                FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("Password","驗證錯誤");

            return View();
        }
        private bool CheckLogin(string p1, string p2) {
            return (p1 == "laba.chuang@gmail.com" && p2 == "123");
        }
        
        /// <summary>登出</summary>
        public ActionResult logout() {    //登出
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}