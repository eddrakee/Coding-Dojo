using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using System.Linq;

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
            ViewBag.AllErrors = ModelState.Values;
            return View();
        }

        // View All Reviews 
        [HttpGet]
        [RouteAttribute("ViewAll")]
        public IActionResult ViewAll()
        {

            // this creates a list of all Reviews from the db 
            List<Review> AllReviews = _context.Reviews.OrderByDescending(rev => rev.UpdatedAt).ToList();
            ViewBag.AllReviews = AllReviews;

            return View("Reviews");
        }

        // Add Review
        [HttpPost]
        [RouteAttribute("AddReview")]
        public IActionResult AddReview(Review NewReview)
        {

            if (ModelState.IsValid)
            {
                NewReview.CreatedAt = DateTime.Now;
                NewReview.UpdatedAt = DateTime.Now;
                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            else
            {
                ViewBag.AllErrors = ModelState.Values;
                return View("Index");
            }

        }
    }
}
