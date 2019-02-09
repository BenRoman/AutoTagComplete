using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cities.Models;
using System.Web.Mvc;

namespace cities.Controllers
{
    public class HomeController : Controller
    {
        #region Add City
        [HttpGet]
        public ActionResult AddCity()
        {
            IEnumerable<string> countries;
            using (var db = new CityContext())
            {
                countries = db.Countries.Select(w=>w.Name).ToList();
            }
            return View(new SelectList(countries));
        }
        [HttpPost]
        public ActionResult AddCity(string country, string cityname)
        {
            using (var db = new CityContext())
            {
                db.Cities.Add(new City() { Name = cityname, CountryId = db.Countries.FirstOrDefault(w => w.Name == country).Id });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<City> cities;
            using (var db = new CityContext())
            {
                cities = db.Cities.ToList();
            }
            return View(cities);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (var db = new CityContext())
            {
                var countries = db.Countries.Select(m => m.Name).ToList();
                var countryOptions = new SelectList(countries);
                return View(countryOptions);
            }
        }
        public ActionResult tmp()
        {
            return View();

        }
        
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string tags)
        {

            return View();

        }
        public ActionResult CitySearcher()
        {
            return View();
        }

        public ActionResult TagAutoComplitter()
        {
            return View();
        }

        
        public JsonResult AllCities()
        {
            using (var db = new CityContext())
            {
                var cities = db.Cities.Select(w=>w.Name).ToList();
                return Json(cities, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult GetStates(string country)
        {
            using (var db = new CityContext())
            {
                var city = db.Cities.Where(c => c.Country.Name == country).Select(m => m.Name).ToList();
                return Json(city, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GetCities(string str)
        {
            using (var db = new CityContext())
            {
                var city = db.Cities.Where(c => c.Name.Contains(str)).Select(m => m.Name).FirstOrDefault();
                return Json(city, JsonRequestBehavior.AllowGet);

            }
        }
    }
}