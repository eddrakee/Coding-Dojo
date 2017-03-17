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
         private readonly MessageFactory messageFactory;
        public MessageController()
        {
            messageFactory = new MessageFactory();
        }
        // POST: Add Message
        [HttpPost]
        [Route("AddMessage")]
        public IActionResult AddMessage(Message newmessage)
        {
            if (ModelState.IsValid)
            {
                
                // int? SessionUser = HttpContext.Session.GetInt32("SessionID");
                // // This is where you would put check if user exists filter here...
                // string QueryNewMessage = $"INSERT INTO Messages (MessageContent, User_Id, CreatedAt) VALUES ('{newmessage.MessageContent}','{SessionUser}', NOW())";
                // _dbConnector.Execute(QueryNewMessage);
                // // Is this the right method?
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ViewBag.MessageError = "";
                return View("Dashboard");
            }
        }


    }
}