using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;
using System.Threading.Tasks;
using NLog;

namespace WebProject.Controllers
{
    public class OrganizerController : Controller
    {
        ObjectHandlerJSON obj = new ObjectHandlerJSON();

        // Role which allows user on this site
        private string allowedRole = "organizer";

        public ActionResult Index()
        {          
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                //ViewBag.userName = Session["userName"].ToString().ToUpper();

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
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

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

                // Loopa through the category list to create dropdown
                foreach (var item in categoriesList)
                {
                    // Create new object every loop
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

                    // pick the place which the facility belongs to
                    place = await obj.GetPlaceByID(item.Fk_Place);

                    // Create a string which includes facility and place name for better readability
                    string location = item.Name + " | " + place.Name.ToString() + " | " + place.City.ToString();

                    temp.Text = location;
                    temp.Value = item.Id.ToString();                   

                    facilitiesDropDown.Add(temp);
                   
                }
                
                // Dropdowns created
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
        public async Task<ActionResult> CreateEvent(Events newEvent, int Category_Id, int FacilityID)
        {

            FacilitiesBooked facilitiesBooked = new FacilitiesBooked();

            try
            {
                newEvent.Event_Category = new EventCategory();
                newEvent.Event_Category.Category_Id = Category_Id;
                newEvent.Event_Create_Datetime = DateTime.Now;

                // Nytt:
                newEvent.Event_Facility = new EventFacility() { Id = FacilityID };

                newEvent.Event_Organizer = new EventOrganizer() { Id = int.Parse(Session["userID"].ToString()) };


                // In case value is null. Value cannot be null
                if (newEvent.Event_Seeking_Volunteers != true)
                {
                    newEvent.Event_Seeking_Volunteers = false;
                }

                if (newEvent.Event_Active != true)
                {
                    newEvent.Event_Active = false;
                }

                // Booked facility
                facilitiesBooked.DateStart = newEvent.Event_Start_Datetime;
                facilitiesBooked.DateEnd = newEvent.Event_End_Datetime;
                facilitiesBooked.Fk_Facility = newEvent.Event_Facility.Id;
                facilitiesBooked.Fk_Organizer = newEvent.Event_Organizer.Id;

                // Add objects in respective database
                await obj.AddFacilitiesBooked(facilitiesBooked);
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
            ObjectHandlerJSON callFunction = new ObjectHandlerJSON();
            var organizerList = await callFunction.GetOrganizerList();      

            try
            {
                var findUser = organizerList.Where(m => m.Email == "reashid@.com");
                foreach (var user in findUser)
                {
                    Session["userID"] = user.Id;
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                var findUser = organizerList.Where(m=>m.Email == "reashid@.com");
                foreach (var user in findUser)
                {
                    Session["userID"] = user.Id;
                }
                // Convert the users id to int
                int id = int.Parse(Session["userID"].ToString());

                //List<EventCategory> eventCategories = new List<EventCategory>();
                List<Events> eventList = new List<Events>();
                List<Events> eventModelList = new List<Events>();

                // Get the lists
                eventList = await obj.GetEventList();
                //eventCategories = await obj.GetCategoryList();
                
                foreach (var item in eventList)
                {
                    if (item.Event_Organizer.Id == id)
                    {
                        eventModelList.Add(item);
                    }
                }
                eventModelList = eventModelList.OrderBy(o => o.Event_Create_Datetime).ToList();
                return View(eventModelList);
            }
            catch(Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            } 
        }
        private bool CheckUserAuthorization()
        {
            // false by default
            bool allowed = false;

            if (Session["userRole"].ToString() != null && Session["userRole"].ToString() == allowedRole)
            {
                allowed = true;
            }

            return allowed;
        }
    }
}