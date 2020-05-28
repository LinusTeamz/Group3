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
        ObjectHandlerJSON obj = new ObjectHandlerJSON();
        // GET: Organizer
        public ActionResult Index()
        {
            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> CreateEvent()
        {
            List<EventCategory> categoriesList = new List<EventCategory>();
            categoriesList = await obj.GetCategoryList();
            List<SelectListItem> categoryDropDown = new List<SelectListItem>();

            foreach (var item in categoriesList)
            {
                SelectListItem temp = new SelectListItem();
                temp.Text = item.Category_Name;
                temp.Value = item.Category_Id.ToString();
                categoryDropDown.Add(temp);
            }

            ViewBag.Category_Id = categoryDropDown;


            return View();
        }
        // POST: CreateE/Create
        [HttpPost]

        public async System.Threading.Tasks.Task<ActionResult> CreateEvent(Event newEvent, int Category_Id)
        {
            newEvent.Event_Category = new EventCategory();
            newEvent.Event_Category.Category_Id = Category_Id;
            newEvent.Event_Create_Datetime = DateTime.Now;
            await obj.AddEvent(newEvent);
            
            return RedirectToAction("Index", "Organizer");
        }

        public ActionResult MyEvent()
        {
            return View();
        }
    }
}