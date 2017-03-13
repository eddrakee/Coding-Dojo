using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string Name, string Location, string Language, string Comment)
        {
            ViewBag.Errors = new List<string>();

            if(Name == null)
            {
                ViewBag.Errors.Add("Please enter a name!");
            }

            if(Location == null)
            {
                ViewBag.Errors.Add("Please select  a location!");
            }

            if(Language == null)
            {
                ViewBag.Errors.Add("Please select a language!");
            }

            if(Comment == null)
            {
                Comment = "";
            }

            if(ViewBag.Errors.Count > 0)
            {
                return View("Index");
            }

            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            
            return View("Success");
        }
    }
}