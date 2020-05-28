using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebProject.Models;
using WebProject.classes;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        ObjectHandlerJSON obj = new ObjectHandlerJSON();

        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                TempData["tempErrorMessage"] = "Password or username is wrong";
                return RedirectToAction("Error", "Help");
            }
           
        }

        // GET: AdminFacility
        public async System.Threading.Tasks.Task<ActionResult> FacilityIndex()
        {
            try
            {
                //if (Session["user"] == null || Session["user"].ToString() != "admin")
                //{
                //    return RedirectToAction("Index", "Home");
                //}

                List<Facility> model = new List<Facility>();
                model = await obj.GetFacilityList();

                return View(model);
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }

        }

        // GET: AdminFacility/Create
        public ActionResult FacilityCreate()
        {
            try
            {
                ////if (Session["user"] == null || Session["user"].ToString() != "admin")
                ////{
                ////    return RedirectToAction("Index", "Home");
                ////}

                return View();
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // POST: AdminFacility/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FacilityCreate(Facility facility)
        {
            try
            {
                await obj.AddFacility(facility);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // GET: AdminFacility/Edit/5
        public ActionResult FacilityEdit(int id)
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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

        // POST: AdminFacility/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FacilityEdit(int id, Facility facility)
        {
            try
            {
                await obj.UpdateFacility(facility);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // GET: AdminFacility/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> FacilityDelete(int id)
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            try
            {
                Facility model = new Facility();
                model = await obj.GetFacilityByID(id);
                return View(model);
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
         
        }

        // POST: AdminFacility/Delete/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FacilityDelete(int id, Facility facility)
        {
            try
            {
                await obj.DeleteFacility(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }
       
        // GET: AdminPlace
        public async System.Threading.Tasks.Task<ActionResult> PlaceIndex()
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            
            try
            {
                List<Place> model = new List<Place>();
                model = await obj.GetPlaceList();
                return View(model);
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = "Password or username is wrong";
                return RedirectToAction("Error", "Help");
            }
        }

        // GET: AdminPlace/Details/5
        public ActionResult PlaceDetails(int id)
        {
            //if (session["user"] == null || session["user"].tostring() != "admin")
            //{
            //    return redirecttoaction("index", "home");
            //}

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

        // GET: AdminPlace/Create
        public ActionResult PlaceCreate()
        {

            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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

        // POST: AdminPlace/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> PlaceCreate(Place place)
        {
            try
            {
                await obj.AddPlace(place);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // GET: AdminPlace/Edit/5
        public ActionResult PlaceEdit(int id)
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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

        // POST: AdminPlace/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> PlaceEdit(int id, Place place)
        {
            try
            {
                await obj.UpdatePlace(place);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // GET: AdminPlace/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> PlaceDelete(int id)
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

         
            try
            {
                Place model = new Place();

                model = await obj.GetPlaceByID(id);

                return View(model);

            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }

        // POST: AdminPlace/Delete/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> PlaceDelete(int id, Place place)
        {
            try
            {
                await obj.DeletePlace(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
        }
    
        
        // GET: Monitoring
        public ActionResult Monitoring()
        {
            //if (Session["user"] == null || Session["user"].ToString() != "admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            try
            {
                ViewModel model = new ViewModel();

                List<bool> resultat = new List<bool>();

                // Lägg in adresser
                List<string> adresser = new List<string>();
                adresser.Add("www.ikea.se");
                adresser.Add("www.google.com");
                adresser.Add("http://193.10.202.76/");
                adresser.Add("http://193.10.202.82/");
                adresser.Add("http://193.10.202.81/");

                int trueCounter = 0;
                int falseCounter = 0;
                foreach (var adress in adresser)
                {
                    MonitorModel namn = new MonitorModel();
                    resultat.Add(GetPing(adress));
                    if (GetPing(adress) == true)
                    {
                        namn.Adress = adress;
                        namn.Ping = true;
                        model.monitorList.Add(namn);
                        trueCounter++;
                    }
                    else
                    {
                        falseCounter++;
                    }
                }
                string result = trueCounter.ToString() + "/" + (falseCounter + trueCounter).ToString();
                //ViewBag.AllaAdresser = adresser;
                //ViewBag.AllaResultat = resultat;
                //ViewBag.Message1 = result;
                return View(model);
            }
            catch (Exception e)
            {
                TempData["tempErrorMessage"] = e.Message.ToString();
                return RedirectToAction("Error", "Help");
            }
          
        }
        public bool GetPing(string adress)
        {
            bool value;
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
    }
}