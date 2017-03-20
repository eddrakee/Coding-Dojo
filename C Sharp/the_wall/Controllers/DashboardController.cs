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
        // This lets us use the factories
        private readonly UserFactory userFactory;
        private readonly MessageFactory messageFactory;
        private readonly CommentFactory commentFactory;
        public DashboardController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
            messageFactory = new MessageFactory();
            commentFactory = new CommentFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
             // This grabs the current logged in user info/object
            ViewBag.CurrentUser =  userFactory.FindByID((int)HttpContext.Session.GetInt32("UserId"));

            // Retreive all Messages
            var AllMessages = messageFactory.AllMessages();
            ViewBag.AllMessages = AllMessages;

            var AllComments = commentFactory.AllComments();
            ViewBag.AllComments = AllComments;

            if(TempData["MessageError"] != null){
                ViewBag.MessageError = TempData["MessageError"];
            }
            return View("Dashboard");
        }


    }
}