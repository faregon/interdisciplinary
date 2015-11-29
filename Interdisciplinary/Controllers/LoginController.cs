﻿using Interdisciplinary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterdisciplinaryDomainModel.Database;
using System.Web.Security;

namespace Interdisciplinary.Controllers
{
    public class LoginController : Controller
    {
        private MysenseiEntities DB = new MysenseiEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            
            var user = DB.Users.FirstOrDefault(x => x.Email.Equals(model.Email));
            
            if (user != null && user.Password == model.Password)
            {
                FormsAuthentication.SetAuthCookie(user.Email, model.RememberMe);
                if (User.IsInRole("Teacher"))
                {

                }
                return RedirectToAction("Index","Home");
            }
            else {
                ModelState.AddModelError("","Wrong credentials");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}