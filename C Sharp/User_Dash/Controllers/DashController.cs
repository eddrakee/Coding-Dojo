using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDash.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                // CurrentUser info is now in ViewBag
                ViewBag.User = CurrentUser;
                // AllUser info is now in ViewBag
                ViewBag.AllUsers = AllUsers;
            if(CurrentUser.UserLevel == 9){
                return View("AdminDashboard");
            }
            return View("UserDashboard");
        }
        // GET: /AddNew/ - Will also check for errors
        [HttpGet]
        [Route("AddNewUser")]
        public IActionResult AddNewUser(){
             List<string> Errors = new List<string>();
            try
            {
                // When it comes back from session, it will be a list of objects.
                List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
                // to make sure they are strings, cast them as strings and put them in Errors
                foreach (object error in Results)
                {
                    Errors.Add(error.ToString());
                }
            }
            catch
            {
                // We don't want it to do anything if there is something wrong.
            }
            ViewBag.Errors = Errors;
            ViewBag.User = _context.Users.Where(w => w.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            return View("AddNewUser");
        }

        [HttpPost]
        [RouteAttribute("AddNewUser")]
        public IActionResult AddNewUser(UserValidation NewUser){
            List<string> Errors = new List<string>();
            if (ModelState.IsValid)
            {
                // Check to see if email already exists...
                User Results = _context.Users.Where(u => u.Email == NewUser.Email).SingleOrDefault();
                if (Results == null)
                {
                    _context.Add(NewUser.ToUser());
                    _context.SaveChanges();
                    // If all good, now send it to the Main method in OtherController
                    return RedirectToAction("Dashboard", "Dash");
                }
                else
                {
                    // Found a user with an existing email in the db
                    Errors.Add("User already exists, please use another email");
                }
            }
            else
            {
                // This makes it easier to access the individule errors on html
                Dictionary<string, string> Error = new Dictionary<string, string>();
                foreach (string key in ViewData.ModelState.Keys)
                {
                    foreach (ModelError error in ViewData.ModelState[key].Errors)
                    {
                        Errors.Add(error.ErrorMessage);
                    }
                }
            }
            HttpContext.Session.SetObjectAsJson("Errors", Errors);
            // Send back to Register as a Json if it didn't work so we can pass it through via redirect
            return RedirectToAction("AddNewUser");
        }
        [HttpGet]
        [Route("Profile/UserId")]
        public IActionResult Profile(){
            
            return View("Profile");
        }
    }
}
