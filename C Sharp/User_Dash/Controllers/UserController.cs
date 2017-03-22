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

    public class UserController : Controller
    {
        private BaseContext _context;
        public UserController(BaseContext context)
        {
            _context = context;
        }
        // The Get route for Register - renders the correct page
        [HttpGet]
        [Route("Register")]
        public IActionResult RegPage()
        {
            List<string> Errors = new List<string>();
            // Use a try catch - it will try to pull from session and if it throws an expection, it will go to catch instead of breaking code
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
            // Either a list of strings or nothing, but we can iterate through either
            ViewBag.Errors = Errors;
            return View("Register");
        }

        // The Post route for Register - this does all the logic
        [HttpPost]
        [RouteAttribute("Register")]
        public IActionResult Register(UserValidation user)
        // Bring in a UserValidation object so we can cast it as a new user object later on
        {
            List<string> Errors = new List<string>();
            if (ModelState.IsValid)
            {
                // Check to see if email already exists...
                User Results = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                // If SingleOrDefault returned null...they don't exist and we need to add them
                if (Results == null)
                {
                    // cast the UserValidation object as a User object
                    _context.Add(user.ToUser());
                    _context.SaveChanges();
                    // Find the user again...
                    Results = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                    // Now set it to session
                    HttpContext.Session.SetInt32("UserId", Results.UserId);
                    // If all good, now send it to the Main method in OtherController
                    // return RedirectToAction("Main", "Other");
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
            return RedirectToAction("RegPage");
        }
        // Login Get Function
        [HttpGet]
        [Route("Login")]
        public IActionResult LogPage()
        {
            List<string> Errors = new List<string>();
            try
            {
                // this checks to see if the user is already in session
                List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
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
            return View("Login");

        }

        // Login Post Function
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserValidation user)
        {
            List<string> Errors = new List<string>();
            if (user.Email == null)
            {
                // We can make our own custom validations becuase it's a list of strings!
                Errors.Add("Emails cannot be blank!");
            }
            if (user.Password == null)
            {
                // We can make our own custom validations becuase it's a list of strings!
                Errors.Add("Password cannot be blank!");
            }
            if (Errors.Count == 0)
            {
                // it worked! Now convert the user that was passed in into normal User called DBUser
                User DBUser = user.ToUser();
                // This looks into our DB and sees if the user exists already
                User Results = _context.Users.Where(u => u.Email == DBUser.Email).SingleOrDefault();
                if(Results != null)
                // this means we found a user that matches!
                {
                    if(Results.Password == DBUser.Password)
                    {
                        // In session, we are creating a var called UserId which contains the UserId for that person
                        HttpContext.Session.SetInt32("UserId", Results.UserId);


                        // NEED TO CHANGE CONTROLLER NAME!
                        // return RedirectToAction("Main", "Bank");
                    }
                }
                Errors.Add("Invalid Email/Password combination! Please try again!");
            }
            //"Key" : Object being turned into a string (which is a list of errors from above)
            HttpContext.Session.SetObjectAsJson("Errors", Errors);
            return RedirectToAction("LogPage");
        }
        [HttpGet]
        [RouteAttribute("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }


}

