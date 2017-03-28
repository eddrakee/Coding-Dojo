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
            // CurrentUser info is now in ViewBag
            ViewBag.User = CurrentUser;
            // AllUser info is now in ViewBag
            ViewBag.AllUsers = AllUsers;
            return View("UserDashboard");
        }
       
    }
}
