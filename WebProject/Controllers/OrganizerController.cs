using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;

namespace WebProject.Controllers
{
    public class OrganizerController : Controller
    {
        // GET: Organizer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateEvent()
        {
            return View();
        }
        public ActionResult MyEvent()
        {
            return View();
        }
    }
}