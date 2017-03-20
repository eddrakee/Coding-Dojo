using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class RestaurantController : Controller
    {
        private RESTauranterContext _context;
        public RestaurantController(RESTauranterContext context)
        {
            _context = context;
        }       

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [RouteAttribute("AddReview")]
        public IActionResult AddReview(){
            Review NewReview = new Review
            {
                Name = "ReviewName",

            };
            _context.AddRevew(NewReview);

        }
    }
}
