using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebProject.classes;
using WebProject.Models;
using System.Threading.Tasks;
using NLog;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        // Add Logger tool object
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // Role which allows user on this site
        private string allowedRole = "organizeradmin";

        // create an object of model "ObjecthandlerJSON" to handle Json code
        private ObjectHandlerJSON obj = new ObjectHandlerJSON();

        public ActionResult Index()
        {
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                return View();
            }
            catch (Exception)
            {
                TempData["tempErrorMessage"] = "Password or username is wrong";
                return RedirectToAction("Error", "Help");
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> FacilityIndex()
        {
            try
            {

                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                List<Facility> model = new List<Facility>();
                model = await obj.GetFacilityList();

                return View(model);
            }
            // Redirect user to Help if an error occurs
            catch (Exception e)
            {
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> FacilityCreate()
        {
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                List<SelectListItem> placeDropDown = new List<SelectListItem>();
                List<Place> placeList = new List<Place>();
                placeList = await obj.GetPlaceList();

                // Loopa igenom kategorier och skapa dropdown
                foreach (var item in placeList)
                {
                    // Skapa nytt objekt vid varje loop
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Name;
                    temp.Value = item.Id.ToString();

                    placeDropDown.Add(temp);
                }
                // Listan omvandlas till viewbag
                ViewBag.Fk_Place = placeDropDown;

                return View();
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FacilityCreate(Facility facility)
        {
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }
                await obj.AddFacility(facility);

                return RedirectToAction("FacilityIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> FacilityEdit(int id)
        {      
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }
                Facility facility = await obj.GetFacilityByID(id);

                List<SelectListItem> placeDropDown = new List<SelectListItem>();
                List<Place> placeList = new List<Place>();
                placeList = await obj.GetPlaceList();

                // Loopa igenom kategorier och skapa dropdown
                foreach (var item in placeList)
                {
                    // Skapa nytt objekt vid varje loop
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Name;
                    temp.Value = item.Id.ToString();
                    if (item.Id == facility.Fk_Place)
                    {
                        temp.Selected = true;

                    }
                    else
                    {
                        temp.Selected = false;
                    }
                    placeDropDown.Add(temp);
                }
                ViewBag.Fk_Place = placeDropDown;
                return View(facility);
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");


                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FacilityEdit(Facility facility)
        {
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                await obj.UpdateFacility(facility);

                return RedirectToAction("FacilityIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> FacilityDelete(int id)
        {
          

            try
            {

                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }
                Facility model = new Facility();
                model = await obj.GetFacilityByID(id);
                return View(model);
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async Task<ActionResult> FacilityDelete(int id, Facility facility)
        {
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                await obj.DeleteFacility(id);

                return RedirectToAction("FacilityIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> PlaceIndex()
        {
        
            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                List<Place> model = new List<Place>();
                model = await obj.GetPlaceList();
                return View(model);
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public ActionResult PlaceCreate()
        {
         

            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                return View();
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> PlaceCreate(Place place)
        {
            try
            {
                await obj.AddPlace(place);

                return RedirectToAction("PlaceIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> PlaceEdit(int id)
        {


            Place place = await obj.GetPlaceByID(id);

            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                return View(place);
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PlaceEdit(int id, Place place)
        {
            try
            {
                await obj.UpdatePlace(place);

                return RedirectToAction("PlaceIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> PlaceDelete(int id)
        {

            try
            {
                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                Place model = new Place();

                model = await obj.GetPlaceByID(id);

                return View(model);
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PlaceDelete(int id, Place place)
        {
            try
            {
                await obj.DeletePlace(id);

                return RedirectToAction("PlaceIndex");
            }
            catch (Exception e)
            {
                // Add logger
                Logger.Error(e, "Error Level");
                Logger.Fatal(e, "Fatal Level");

                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        public async Task<ActionResult> Monitoring()
        {
         
            try
            {

                if (!CheckUserAuthorization())
                {
                    return RedirectToAction("Login", "Home");
                }

                List<MonitorModel> monitorList = new List<MonitorModel> {
                new MonitorModel{GroupName = "Group 1", BaseAdress = "http://193.10.202.76/", ApiURL = "api/visitor"},
                new MonitorModel{GroupName = "Group 2", BaseAdress = "http://193.10.202.77/", ApiURL = "EventService"},
                new MonitorModel{GroupName = "Group 3", BaseAdress = "http://193.10.202.78/", ApiURL = "EventLokal"},
                new MonitorModel{GroupName = "Group 4", BaseAdress = "http://193.10.202.81/", ApiURL = "BookingService"},
                new MonitorModel{GroupName = "Group 5", BaseAdress = "http://193.10.202.82/MyProfile/", ApiURL = "api/Profiles/GetProfile"},
                };

                ViewModel model = new ViewModel();
                int trueCounter = 0;
                int falseCounter = 0;

                foreach (var item in monitorList)
                {
                    ObjectHandlerJSON callFunction = new ObjectHandlerJSON();
                    item.Ping = await callFunction.GetStatusFromAPI(item.BaseAdress, item.ApiURL);
                    if (item.Ping)
                    {
                        trueCounter++;
                        item.status = "Running";
                    }
                    else
                    {
                        falseCounter++;
                        item.status = "Offline";
                    }
                }
                model.monitorList = monitorList;
                string result = trueCounter.ToString() + "/" + (falseCounter + trueCounter).ToString();
                ViewBag.Message1 = result;
                return View(model);
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        private bool GetPing(string adress)
        {
            bool value;
            
            //  Request to ping a an adress
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var result = ping.Send(adress);

                if (result.Status.ToString().ToLower().Equals("success"))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            catch
            {
                return false;
            }
            return value;
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