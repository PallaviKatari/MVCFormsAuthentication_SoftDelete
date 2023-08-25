using MVCFormsAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCFormsAuthentication.Controllers
{

    public class HomeController : Controller
    {
        private readonly MVCAuthenticationEntities _dbContext = new MVCAuthenticationEntities();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _dbContext.Users
               .Any(u => u.Username.ToLower() == user
               .Username.ToLower() && user
               .Password == user.Password);

                if (IsValidUser)
                {
                    //As you can see in the Post method, first we validate the user,
                    //and if the validation is a success, then we call the SetAuthCookie method
                    //of FormsAuthentication class and then navigate the user to the
                    //Index method of Employees Controller. The FormsAuthentication class
                    //is available in System.Web.Security namespace.
                    //We are passing the username as the first parameter to the SetAuthCookie method.
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Employees");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(registerUser);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");

            }
            return View();
        }

    }
}