using FootballApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballApp.Models;

namespace FootballApp.Controllers
{
    public class HomeController : Controller
    {
        private FootballAppContext db = new FootballAppContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _RandomFootballer()
        {
            
                Random rnd = new Random();

                var query = from footballer in db.Footballers select footballer;
                int range = query.Count();
                int random = rnd.Next(range);
                List<Footballer> fb = new List<Footballer>();
                foreach (Footballer f in query)
                {
                    fb.Add(f);
                }

                var v = fb.ElementAt(random);

                return PartialView("_RandomFootballer", v);
            
        }

    }
}