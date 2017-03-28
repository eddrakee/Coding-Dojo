using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDash.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace UserDash.Controllers
{
    public class DashController : Controller
    {
        private BaseContext _context;
        public DashController(BaseContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            // Get the user's info that matches the session User
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            // Populate all users and put it in a list
            List<User> AllUsers = _context.Users
                .OrderBy(u => u.UserId)
                .ToList();
            List<Activity> AllActivities = _context.Activity.ToList();
            ViewBag.AllActivities = AllActivities;
            ViewBag.User = CurrentUser;
            ViewBag.AllUsers = AllUsers;

            return View("Dashboard");
        }
        // ADD ACTIVITY - GET
        [HttpGet]
        [RouteAttribute("AddActivity")]
        public IActionResult AddActivity()
        {
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            ViewBag.User = CurrentUser;
            return View("AddActivity");
        }
        // ADD ACTIVITY - POST
        [HttpPost]
        [RouteAttribute("AddActivity")]
        public IActionResult AddActivity(Activity NewActivity)
        {
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            if (ModelState.IsValid)
            {
                NewActivity.ActivityCreatorId = CurrentUser.UserId;
                NewActivity.ActivityJoinerId = CurrentUser.UserId;
                NewActivity.CreatedAt = DateTime.Now;
                NewActivity.UpdatedAt = DateTime.Now;
                _context.Add(NewActivity);
                _context.SaveChanges();
                Activity JustAdded = _context.Activity.Where( i => i.ActivityId == NewActivity.ActivityId).SingleOrDefault();  
                return RedirectToAction("ShowOne", new {ActivityId = NewActivity.ActivityId});
            }
            else
            {
                ViewBag.AllErrors = ModelState.Values;
                return View("AddActivity");
            }
        }
        // SHOW ONE ACTIVITY - GET
        [HttpGet]
        [RouteAttribute("ShowOne/{ActivityId}")]
        public IActionResult ShowOne(int ActivityId)
        {
            
            Activity ActivityProfile = _context.Activity.SingleOrDefault( i => i.ActivityId == ActivityId);
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId"));
            ViewBag.User = CurrentUser;
            ViewBag.Profile = ActivityProfile;
            return View("ShowOne");
        }
        // DELETE ACTIVITY - GET
        [HttpGet]
        [RouteAttribute("Delete/{ActivityId}")]
        public IActionResult Delete(int ActivityId)
        {
            Activity DeleteAct = _context.Activity.SingleOrDefault( d => d.ActivityId == ActivityId);
            _context.Activity.Remove(DeleteAct);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
