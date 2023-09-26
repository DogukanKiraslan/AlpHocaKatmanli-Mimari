using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommaranceWithLayeredArchManagerUI.Helpers;
using ecommaranceWithLayeredArchManagerUI.Models;
using ecommaranceWithLayeredArchDomain.Entities;
using ecommaranceWithLayeredArchPersistance.Content;

namespace ecommaranceWithLayeredArchManagerUI.Controllers
{
    public class LoginController : Controller
    {
        ecommaranceContext model = new ecommaranceContext();

        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(ManagerLoginModel mlm) 
        {        
            if(mlm.email != null && mlm.password != null)
            {
                string password = PasswordHelper.DESSifrele(mlm.password);
                User user = model.Users.FirstOrDefault(x => x.Email == mlm.email && x.Password == password);
                if (user == null)
                {
                    ViewBag.result = ">:(";
                    return View();
                }
                else
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Product");
                }
            }
            ViewBag.result = ">:(";
            return View();
        }
    }
}