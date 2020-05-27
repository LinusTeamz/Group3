﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {

        //Arrangör namn: dennis@live.se 
        //Arrangör psw: hejhej123

        public ActionResult Login()
        {
            // Tar bort session vid start
            Session.Remove("user");

            // Skriv enbart ut ifall det finns data
            if (TempData.ContainsKey("tempErrorMessage"))
            {
                // Skriver ut felmeddelandet
                ViewBag.ErrorMessage ="* " + TempData["tempErrorMessage"].ToString();

                // Ta bort temp data efter användning
                TempData.Remove("tempErrorMessage");
            }

            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(LoginModel loginDetails)
        {
            LoginHandler handler = new LoginHandler();

            try
            {            
                string role = await handler.UserDetails(loginDetails.name, loginDetails.password);

                if (role.Equals("Arrangör"))
                {
                    Session["user"] = role;
                    return RedirectToAction("Index", "Organizer");
                }
                else if (role.Equals("Admin"))
                {
                    Session["user"] = role;
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Login", "Home");
            }
            catch(Exception e)
            {
                TempData["tempErrorMessage"] = e.Message;
                return RedirectToAction("Login", "Home");
            }
        }
    }
}