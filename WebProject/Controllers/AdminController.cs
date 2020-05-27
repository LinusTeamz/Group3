using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.classes;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
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