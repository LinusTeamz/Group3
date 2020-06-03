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
        // Admin namn: disney@.com
        // Admin psw: organizer

        public ActionResult Login()
        {


            // If user did not log out, the user will be redirected to the proper site
            if (Session["userRole"] != null && Session["userRole"].ToString().Equals("organizeradmin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (Session["userRole"] != null && Session["userRole"].ToString().Equals("organizer"))
            {
                return RedirectToAction("Index", "Organizer");
            }
            else
            {
                // Remove all sessions if any of the above is not correct
                RemoveAllSessions();
            }

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
          
            try
            {
                // Get admin permission first. permission must be sent same time, otherwise API wont accept it. 
                loginDetails.permission = "organizeradmin";

                // Replace old values
                loginDetails = await handler.UserAuthorized(loginDetails);

                // If invalid the role is liekly null and the password, username can be wrong. Alternativley the service can be down.
                if(loginDetails != null)
                {
                    if (loginDetails.permission != null && loginDetails.permission.Equals("organizer"))
                    {
                        Session["userRole"] = loginDetails.permission;
                        Session["userID"] = loginDetails.Id;
                        return RedirectToAction("Index", "Organizer");
                    }
                    // Different redirect than user
                    else if (loginDetails.permission != null && loginDetails.permission.Equals("organizeradmin"))
                    {
                        Session["userRole"] = loginDetails.permission;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        TempData["tempErrorMessage"] = "Password or username is wrong";
                        return RedirectToAction("Login", "Home");
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