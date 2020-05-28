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
        // GET: Organizer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateEvent()
        {

            return View();
        }
        // POST: CreateE/Create
        [HttpPost]

        public async Task<ActionResult> CreateEvent(Event newEvent, int Category_Id)
        {
            newEvent.Event_Category = new EventCategory();
            newEvent.Event_Category.Category_Id = Category_Id;
            newEvent.Event_Create_Datetime = DateTime.Now;
            await obj.AddEvent(newEvent);
            
            return RedirectToAction("Index", "Organizer");
        }

        public async Task<ActionResult> MyEvent()
        {
            int id = 1;
            List<Event> eventList = new List<Event>();
            List<Event> eventModelList = new List<Event>();
            eventList = await obj.GetEventList();
            foreach (var item in eventList)
            {
                if (item.Event_Arranger_Id == id)
                {
                    eventModelList.Add(item);
                }
            }
            return View(eventModelList);
        }
    }
}