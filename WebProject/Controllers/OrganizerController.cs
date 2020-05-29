using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;
using System.Threading.Tasks;

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
        public async Task<ActionResult> CreateEvent()
        {          
            try
            {
                // List of dropdown items
                List<SelectListItem> facilitiesDropDown = new List<SelectListItem>();
                List<SelectListItem> categoryDropDown = new List<SelectListItem>();

                // Lists for category, facility and places
                List<EventCategory> categoriesList = new List<EventCategory>();
                List<Facility> facilitiesList = new List<Facility>();
                List<Place> placeList = new List<Place>();

                categoriesList = await obj.GetCategoryList();
                facilitiesList = await obj.GetFacilityList();
                placeList = await obj.GetPlaceList();

                // Loopa igenom kategorier och skapa dropdown
                foreach (var item in categoriesList)
                {
                    // Skapa nytt objekt vid varje loop
                    SelectListItem temp = new SelectListItem();

                    temp.Text = item.Category_Name;
                    temp.Value = item.Category_Id.ToString();

                    categoryDropDown.Add(temp);
                }

                // Loopa igenom facilities och skapa dropdown
                foreach (var item in facilitiesList)
                {
                    SelectListItem temp = new SelectListItem();
                    Place place = new Place();

                    // Plocka ut plats som en lokal tillhör
                    place = await obj.GetPlaceByID(item.Fk_Place);

                    // skapa ett bättre namn för användaren
                    string location = item.Name + " - " + place.Name.ToString();

                    temp.Text = location;
                    temp.Value = item.Id.ToString();                   

                    facilitiesDropDown.Add(temp);
                   
                }
      
                // Dropdowns skapas
                ViewBag.Category_Id = categoryDropDown;
                ViewBag.FacilityID = facilitiesDropDown;

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
        public async Task<ActionResult> CreateEvent(Event newEvent, int Category_Id, int FacilityID, int OrganizerID)
        {

            FacilitiesBooked facilitiesBooked = new FacilitiesBooked();

            try
            {
                newEvent.Event_Category = new EventCategory();
                newEvent.Event_Category.Category_Id = Category_Id;
                newEvent.Event_Create_Datetime = DateTime.Now;

                // Nytt:
                newEvent.Event_Facility = new EventFacility() { Id = FacilityID };

                newEvent.Event_Organizer = new EventOrganizer() { Id = OrganizerID };

                if (newEvent.Event_Seeking_Volunteers != true)
                {
                    newEvent.Event_Seeking_Volunteers = false;
                }

                if (newEvent.Event_Active != true)
                {
                    newEvent.Event_Active = false;
                }

                await obj.AddEvent(newEvent);
             

                // Om allt går bra
                return RedirectToAction("Index", "Organizer");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> MyEvent()
        {
            int id = 1;

            List<Event> eventList = new List<Event>();
            List<Event> eventModelList = new List<Event>();

            eventList = await obj.GetEventList();
            foreach (var item in eventList)
            {
                if (item.Event_Organizer.Id == id)
                {
                    eventModelList.Add(item);
                }
            }
            return View(eventModelList);
        }
    }
}