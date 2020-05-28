﻿using System;
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
        public ActionResult CreateEvent()
        {

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