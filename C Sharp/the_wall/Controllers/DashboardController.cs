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
    public class DashboardController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly MessageFactory messageFactory;
        // private readonly CommentFactory commentFactory;
        public DashboardController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
            messageFactory = new MessageFactory();
            // commentFactory = new CommentFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
             // This grabs the current logged in user info/object
            User CurrentUser = userFactory.FindByID((int)HttpContext.Session.GetInt32("UserId"));
            ViewBag.CurrentUser = CurrentUser;

            // Retreive all Messages
            var AllMessages = messageFactory.AllMessages();

            ViewBag.AllMessages = AllMessages;

            return View("Dashboard");
        }


    }
}