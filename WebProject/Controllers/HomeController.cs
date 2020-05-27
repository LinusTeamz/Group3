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

            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(LoginModel loginDetails)
        {
            LoginHandler handler = new LoginHandler();
            string role = await handler.UserDetails(loginDetails.name, loginDetails.password);        

            if (role.Equals("Arrangör"))
            {
                Session["user"] = role;
                return RedirectToAction("Index","Arrangör");
            }
            else if (role.Equals("Admin"))
            {
                Session["user"] = role;
                return RedirectToAction("Index","Admin");
            }

            return RedirectToAction("Login", "Home");
        }
    }

}