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
            return View();
        }

        // GET: AdminFacility
        public async System.Threading.Tasks.Task<ActionResult> FacilityIndex()
        {
            try
            {
                
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
                if (Session["user"] == null || Session["user"].ToString() != "admin")
                {
                    return RedirectToAction("Index", "Home");
                }

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
        public ActionResult FacilityCreate(Facility facility)
        {
            try
            {
                obj.AddFacility(facility);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminFacility/Edit/5
        public ActionResult FacilityEdit(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: AdminFacility/Edit/5
        [HttpPost]
        public ActionResult FacilityEdit(int id, Facility facility)
        {
            try
            {
                obj.UpdateFacility(facility);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminFacility/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> FacilityDelete(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            Facility model = new Facility();

            model = await obj.GetFacilityByID(id);

            return View(model);
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
            catch
            {
                return View();
            }
        }
        // GET: AdminOrganizer
        public async System.Threading.Tasks.Task<ActionResult> OrganizerIndex()
        {
            

            ObjectHandlerJSON json = new ObjectHandlerJSON();
            List<Organizer> model = new List<Organizer>();
            model = await json.GetOrganizerList();

            return View(model);
        }

        // GET: AdminOrganizer/Details/5
        public ActionResult OrganizerDetails(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: AdminOrganizer/Create
        public ActionResult OrganizerCreate()
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: AdminOrganizer/Create
        [HttpPost]
        public ActionResult OrganizerCreate(Organizer organizer)
        {
            try
            {
                obj.AddOrganizer(organizer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrganizer/Edit/5
        public ActionResult OrganizerEdit(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: AdminOrganizer/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> OrganizerEdit(int id, Organizer organizer)
        {
            try
            {
                await obj.UpdateOrganizer(organizer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrganizer/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> OrganizerDelete(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            Organizer model = new Organizer();

            model = await obj.GetOrganizerByID(id);

            return View(model);
        }

        // POST: AdminOrganizer/Delete/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> OrganizerDelete(int id, Place place)
        {
            try
            {
                await obj.DeleteOrganizer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminPlace
        public async System.Threading.Tasks.Task<ActionResult> PlaceIndex()
        {

            ObjectHandlerJSON json = new ObjectHandlerJSON();
            List<Place> model = new List<Place>();
            model = await json.GetPlaceList();

            return View(model);
        }

        // GET: AdminPlace/Details/5
        public ActionResult PlaceDetails(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: AdminPlace/Create
        public ActionResult PlaceCreate()
        {

            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: AdminPlace/Create
        [HttpPost]
        public ActionResult PlaceCreate(Place place)
        {
            try
            {
                obj.AddPlace(place);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPlace/Edit/5
        public ActionResult PlaceEdit(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
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
            catch
            {
                return View();
            }
        }

        // GET: AdminPlace/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> PlaceDelete(int id)
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            Place model = new Place();

            model = await obj.GetPlaceByID(id);

            return View(model);
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
            catch
            {
                return View();
            }
        }
    
        
        // GET: Monitoring
        public ActionResult Monitoring()
        {
            if (Session["user"] == null || Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            List<bool> resultat = new List<bool>();
            List<string> adresser = new List<string>();
            adresser.Add("www.ikea.se");
            adresser.Add("www.google.com");
            adresser.Add("www.inet.se");
            adresser.Add("www.magnusgoogle.com");
            adresser.Add("www.aftonbladet.se");

            int trueCounter = 0;
            int falseCounter = 0;
            foreach (var adress in adresser)
            {
                MonitorModel namn = new MonitorModel();
                resultat.Add(GetPing(adress));
                if (GetPing(adress) == true)
                {
                    trueCounter++;
                }
                else
                {
                    falseCounter++;
                }
            }
            string result = trueCounter.ToString() + "/" + (falseCounter + trueCounter).ToString();
            ViewBag.AllaAdresser = adresser;
            ViewBag.AllaResultat = resultat;
            ViewBag.Message1 = result;
            return View();
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
            catch (Exception e)
            {
                return false;
            }
            return value;
        }
    }
}