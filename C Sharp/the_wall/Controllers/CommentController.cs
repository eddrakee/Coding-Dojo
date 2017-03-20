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
    public class CommentController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly CommentFactory commentFactory;
        public CommentController()
        {
            userFactory = new UserFactory();
            commentFactory = new CommentFactory();
        }
        // POST: Add Message
        [HttpPost]
        [Route("AddComment")]
        public IActionResult AddComment(Comment newcomment)
        {
            if (ModelState.IsValid)
            {
                commentFactory.AddComment(newcomment);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ViewBag.CurrentUser = userFactory.FindByID((int)HttpContext.Session.GetInt32("UserId"));
                TempData["MessageError"]="Comments must be 5 characters long";
                return RedirectToAction("Dashboard", "Dashboard");
            }
        }


    }
}