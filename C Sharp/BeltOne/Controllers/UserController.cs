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
            try
            {
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
            return View("Register");
        }

        // The Post route for Register - this does all the logic
        [HttpPost]
        [RouteAttribute("Register")]
        public IActionResult Register(UserValidation user)
        {
            List<string> Errors = new List<string>();
            if (ModelState.IsValid)
            {
                User Results = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                if (Results == null)
                {
                    _context.Add(user.ToUser());
                    _context.SaveChanges();
                    Results = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("UserId", Results.UserId);
                    return RedirectToAction("Dashboard", "Dash");
                }
                else
                {
                    Errors.Add("User already exists, please use another email");
                }
            }
            else
            {
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
                Errors.Add("Emails cannot be blank!");
            }
            if (user.Password == null)
            {
                Errors.Add("Password cannot be blank!");
            }
            if (Errors.Count == 0)
            {
                User DBUser = user.ToUser();
                User Results = _context.Users.Where(u => u.Email == DBUser.Email).SingleOrDefault();
                if(Results != null)
                {
                    if(Results.Password == DBUser.Password)
                    {
                        HttpContext.Session.SetInt32("UserId", Results.UserId);
                      return RedirectToAction("Dashboard", "Dash");
                    }
                }
                Errors.Add("Invalid Email/Password combination! Please try again!");
            }
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

