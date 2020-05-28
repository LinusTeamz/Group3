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

        public ActionResult Index()
        {          
            try
            {
                return View();
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }
        public async System.Threading.Tasks.Task<ActionResult> CreateEvent()
        {          
            try
            {
                List<SelectListItem> categoryDropDown = new List<SelectListItem>();
                List<EventCategory> categoriesList = new List<EventCategory>();

                categoriesList = await obj.GetCategoryList();
              
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
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }
        // POST: CreateE/Create
        [HttpPost]

        public async System.Threading.Tasks.Task<ActionResult> CreateEvent(Event newEvent, int Category_Id)
        {      
            try
            {
                newEvent.Event_Category = new EventCategory();
                newEvent.Event_Category.Category_Id = Category_Id;
                newEvent.Event_Create_Datetime = DateTime.Now;
                await obj.AddEvent(newEvent);
                
                return RedirectToAction("Index", "Organizer");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public ActionResult MyEvent()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }
    }
}