using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> test()
        {
            ObjectHandlerJSON json = new ObjectHandlerJSON();
            var test = await json.GetFacilityList();
            
            return View();
        }
    }
}