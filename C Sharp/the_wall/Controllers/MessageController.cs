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
    public class MessageController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly MessageFactory messageFactory;
        public MessageController()
        {
            messageFactory = new MessageFactory();
            userFactory = new UserFactory();
        }
        // POST: Add Message
        [HttpPost]
        [Route("AddMessage")]
        public IActionResult AddMessage(Message newmessage)
        {
            if (ModelState.IsValid)
            {
                messageFactory.AddMessage(newmessage);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ViewBag.CurrentUser = userFactory.FindByID((int)HttpContext.Session.GetInt32("UserId"));
                TempData["MessageError"]="Messages must be 5 characters long";
                return RedirectToAction("Dashboard", "Dashboard");
            }
        }


    }
}