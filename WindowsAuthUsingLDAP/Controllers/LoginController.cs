using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WindowsAuthUsingLDAP.Models;

namespace WindowsAuthUsingLDAP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var userName = loginModel.UserName;
            var passWord = loginModel.Password;
            bool isValid = AuthenticateUser.IsValidUser(userName, passWord);
            if (isValid)
            {
                ViewData["Message"] = "Successfully Logged In";
            }
            else
            {
                ViewData["Message"] = "Invalid Login Credentials";
            }


            return View("Success");
        }

    }
}