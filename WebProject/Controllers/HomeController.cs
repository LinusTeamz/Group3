using System;
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

        //Arrangör namn: user alternativt reashid@.com
        //Arrangör psw: user

        // Admin namn: disney@.com
        // Admin psw: organizer

        public ActionResult Login()
        {
      

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

        // Login function logic
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(organizerlogin loginDetails)
        {
            LoginHandler handler = new LoginHandler();

            // Hardcoded user
            if(loginDetails.password == "user" && loginDetails.username == "user")
            {
                Session["userRole"] = "organizer";
                Session["userName"] = loginDetails.username;
                Session["userID"] = 2;
                return RedirectToAction("Index", "Organizer");
            }
            
            try
            {
                // Get admin permission first. permission must be sent same time, otherwise API wont accept it. 
                loginDetails.permission = "organizeradmin";
                string role = await handler.UserAuthorized(loginDetails);

                // If invalid the role is liekly null and the password, username can be wrong. Alternativley the service can be down.
                if(role != "invalid")
                {
                    if (role.Equals("organizer"))
                    {
                        Session["userRole"] = role;
                        return RedirectToAction("Index", "Organizer");
                    }
                    // Different redirect than user
                    else if (role.Equals("organizeradmin"))
                    {
                        Session["userRole"] = role;
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    // Remove session just in case
                    RemoveAllSessions();
                }

                TempData["tempErrorMessage"] = "Password or username is wrong";
                return RedirectToAction("Login", "Home");  
            }
            // Redirect user to Home if username and password does not match
            catch(Exception e)
            {
                TempData["tempErrorMessage"] = e.Message;
                return RedirectToAction("Login", "Home");
            }
        }
        // Remove session when user logs out
        public ActionResult Logout()
        {
            RemoveAllSessions();
            return RedirectToAction("Login", "Home");
        }
        private void RemoveAllSessions()
        {
            Session.Remove("userID");
            Session.Remove("userName");
            Session.Remove("userRole");
        }
    }
}