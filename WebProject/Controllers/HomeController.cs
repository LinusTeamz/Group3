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

        // Login function logic
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(organizerlogin loginDetails)
        {
            LoginHandler handler = new LoginHandler();
            // Try to verify if user is organizer or admin
            try
            {            
                string role = await handler.UserDetails(loginDetails.name, loginDetails.password);

                if(role != null)
                {
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
            Session.Remove("user");
            return RedirectToAction("Login", "Home");
        }
    }
}