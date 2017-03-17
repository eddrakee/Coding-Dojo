using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using the_wall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using the_wall.Factory;

namespace the_wall.Controllers
{

    public class UserController : Controller
    {
        private readonly UserFactory userFactory;
        public UserController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.RegErrors = new List<string>();
            ViewBag.LogError = "";
            return View();
        }

        // Post for /Register
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Does this user exist in our db already?
                User UserExist = userFactory.FindByEmail(user.Email);
                if (UserExist == null)
                {
                    // If they don't exist, we will add them
                    userFactory.Add(user);
                    // To set session
                    UserExist = userFactory.FindByEmail(user.Email);
                    HttpContext.Session.SetInt32("UserId", (int)UserExist.UserId);
                    // Upon success go to Dashboard
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ViewBag.LogError = "User Already Exists!";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.RegErrors = ModelState.Values;
                ViewBag.LogError = "";
                return View("Index");
            }
        }

        // Login Route
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            // If the Email or Password field are empty...
            if (Email == null || Password == null)
            {
                ViewBag.LogError = "Please enter values in both fields!";
                return View("Index");
            }
            // If the password combo is correct...
            User UserExist = userFactory.FindByEmail(Email);
            if (UserExist.Password == Password)
            {
                // Set session as their information
                HttpContext.Session.SetInt32("UserId", (int)UserExist.UserId);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            ViewBag.LogError = "Invalid Combination!";
            ViewBag.RegErrors = new List<string>();
            return View("Index");

        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}