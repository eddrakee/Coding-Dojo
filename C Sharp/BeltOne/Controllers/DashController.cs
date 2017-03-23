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
        // LOAD DASHBOARD
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            List<User> AllUsers = _context.Users
                .OrderBy(u => u.UserId)
                .ToList();
            ViewBag.User = CurrentUser;
            ViewBag.AllUsers = AllUsers;
            return View("Dashboard");
        }
        // LOAD ALL USERS
        [HttpGet]
        [Route("AllUsers")]
        public IActionResult AllUsers()
        {
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            List<User> AllUsers = _context.Users
                .OrderBy(u => u.UserId)
                .ToList();
            ViewBag.User = CurrentUser;
            ViewBag.AllUsers = AllUsers;
            return View("ShowAll");
        }
        // VIEW PROFILE FOR SPECIFIC USER
        [HttpGet]
        [RouteAttribute("Profile/{UserId}")]
        public IActionResult Profile(int UserId)
        {
            ViewBag.User = _context.Users.Where(o => o.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            User ProfileUser = _context.Users.SingleOrDefault(u => u.UserId == UserId);
            ViewBag.Profile = ProfileUser;
            return View("Profile");
        }
        // ADD FRIEND - GET
        [HttpGet]
        [Route("AddFriend/{UserId}")]
        public IActionResult AddFriend(int UserId)
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
                // Don't want any errors if something goes wrong
            }
            ViewBag.Errors = Errors;
            ViewBag.User = _context.Users.SingleOrDefault(w => w.UserId == UserId);
            return View("ShowAll");
        }
        // ADD FRIEND - GET
        [HttpGet]
        [Route("AddFriend/{UserId}")]
        public IActionResult AddFriend(int UserId)


            // Or does this need to be return View to ShowAll?
            // return RedirectToAction("AllUsers");






        // // GET: /AddNewUser/ - Will also check for errors
        // [HttpGet]
        // [Route("AddNewUser")]
        // public IActionResult AddNewUser()
        // {
        //     List<string> Errors = new List<string>();
        //     try
        //     {
        //         // When it comes back from session, it will be a list of objects.
        //         List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
        //         // to make sure they are strings, cast them as strings and put them in Errors
        //         foreach (object error in Results)
        //         {
        //             Errors.Add(error.ToString());
        //         }
        //     }
        //     catch
        //     {
        //         // We don't want it to do anything if there is something wrong.
        //     }
        //     ViewBag.Errors = Errors;
        //     ViewBag.User = _context.Users.Where(w => w.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
        //     return View("AddNewUser");
        // }

        // [HttpPost]
        // [RouteAttribute("AddNewUser")]
        // public IActionResult AddNewUser(UserValidation NewUser)
        // {
        //     List<string> Errors = new List<string>();
        //     if (ModelState.IsValid)
        //     {
        //         // Check to see if email already exists...
        //         User Results = _context.Users.Where(u => u.Email == NewUser.Email).SingleOrDefault();
        //         if (Results == null)
        //         {
        //             _context.Add(NewUser.ToUser());
        //             _context.SaveChanges();
        //             // If all good, now send it to the Main method in OtherController
        //             return RedirectToAction("Dashboard", "Dash");
        //         }
        //         else
        //         {
        //             // Found a user with an existing email in the db
        //             Errors.Add("User already exists, please use another email");
        //         }
        //     }
        //     else
        //     {
        //         // This makes it easier to access the individule errors on html
        //         Dictionary<string, string> Error = new Dictionary<string, string>();
        //         foreach (string key in ViewData.ModelState.Keys)
        //         {
        //             foreach (ModelError error in ViewData.ModelState[key].Errors)
        //             {
        //                 Errors.Add(error.ErrorMessage);
        //             }
        //         }
        //     }
        //     HttpContext.Session.SetObjectAsJson("Errors", Errors);
        //     // Send back to Register as a Json if it didn't work so we can pass it through via redirect
        //     return RedirectToAction("AddNewUser");
        // }
        // // Show User Profile
        // [HttpGet]
        // [Route("MyProfile/{UserId}")]
        // public IActionResult Profile(int UserId)
        // {
        //     List<string> Errors = new List<string>();
        //     try
        //     {
        //         List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
        //         foreach (object error in Results)
        //         {
        //             Errors.Add(error.ToString());
        //         }
        //     }
        //     catch
        //     {
        //         // We don't want it to do anything if there is something wrong.
        //     }
        //     ViewBag.Errors = Errors;
        //     // Get the user's info that matches the session User
        //     User ProfileUser = _context.Users.Where(u => u.UserId == UserId)
        //         // populated Messages received
        //         // Since messages doesnt have any related functions, we don't need a controller
        //         .Include(m => m.MessagesReceived)
        //             // All comments for those messages
        //             .ThenInclude(c => c.Comments)
        //             // All the user info for those comments
        //             .ThenInclude(u => u.CommentAuthor)
        //         // Each include chain can only go through one field so we have to reinclude again
        //         .Include( a => a.MessagesReceived)
        //             .ThenInclude( b => b.MessageAuthor)
        //         // this returns just the one user we were looking for
        //         .SingleOrDefault();

        //     // CurrentUser info is now in ViewBag
        //     ViewBag.User = _context.Users.Where(o => o.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
        //     // AllUser info is now in ViewBag
        //     ViewBag.Profile = ProfileUser;
        //     return View("Profile");
        // }
        // // Edit User Profile
        // [HttpGet]
        // [Route("EditUser/{UserId}")]
        // public IActionResult EditUser(int UserId)
        // {
        //     List<string> Errors = new List<string>();
        //     try
        //     {
        //         List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
        //         foreach (object error in Results)
        //         {
        //             Errors.Add(error.ToString());
        //         }
        //     }
        //     catch
        //     {
        //         // We don't want it to do anything if there is something wrong.
        //     }
        //     ViewBag.Errors = Errors;
        //     ViewBag.User = _context.Users.SingleOrDefault(w => w.UserId == UserId);
        //     return View("EditUser");
        // }
        // [HttpPost]
        // [RouteAttribute("EditUser")]
        // // WHAT DO I NEED TO PASS IN?
        // public IActionResult EditUser(UserValidation NewUser)
        // {
        //     List<string> Errors = new List<string>();
        //     if (ModelState.IsValid)
        //     {
        //         // converts from a UserValidation obj to a User obj
        //         User Data = NewUser.ToUser();
        //         // Find the old user
        //         User OldUser = _context.Users.Where(u => u.Email == NewUser.Email).SingleOrDefault();
        //         // Update old user to have the newly inserted info
        //         OldUser.Email = Data.Email;
        //         OldUser.FirstName = Data.FirstName;
        //         OldUser.LastName = Data.LastName;
        //         OldUser.Description = NewUser.Description;
        //         OldUser.Password = Data.Password;
        //         OldUser.UpdatedAt = DateTime.Now;
        //         _context.SaveChanges();

        //         // Now send it to the Dashboard Method
        //         return RedirectToAction("Dashboard");

        //     }
        //     else
        //     // If model state fails, it will list errors
        //     {
        //         // This makes it easier to access the individule errors on html
        //         Dictionary<string, string> Error = new Dictionary<string, string>();
        //         foreach (string key in ViewData.ModelState.Keys)
        //         {
        //             foreach (ModelError error in ViewData.ModelState[key].Errors)
        //             {
        //                 Errors.Add(error.ErrorMessage);
        //             }
        //         }
        //     }
        //     HttpContext.Session.SetObjectAsJson("Errors", Errors);
        //     // Send back to Register as a Json if it didn't work so we can pass it through via redirect
        //     return RedirectToAction("EditUser", new { UserId = NewUser.UserId });
        // }
        // // Delete User
        // [HttpGet]
        // [Route("DeleteUser/{UserId}")]
        // public IActionResult DeleteUser(int UserId)
        // {
        //     User TempUser = _context.Users.SingleOrDefault(w => w.UserId == UserId);
        //     _context.Remove(TempUser);
        //     _context.SaveChanges();
        //     return RedirectToAction("Dashboard");
        // }
        // // Post Message
        // [HttpPost]
        // [Route("LeaveMessage")]
        // public IActionResult LeaveMessage(MessageValidation NewMessage)
        // {
        //     List<string> Errors = new List<string>();
        //     if (ModelState.IsValid)
        //     {
        //         Message Data = NewMessage.ToMessage();
        //         Data.CreatedAt = DateTime.Now;
        //         Data.UpdatedAt = DateTime.Now;
        //         _context.Add(Data);
        //         _context.SaveChanges();

        //         return RedirectToAction("Profile", new { UserId = NewMessage.MessageRecipientId});
        //     }
        //     else
        //     // If model state fails, it will list errors
        //     {
        //         // This makes it easier to access the individule errors on html
        //         Dictionary<string, string> Error = new Dictionary<string, string>();
        //         foreach (string key in ViewData.ModelState.Keys)
        //         {
        //             foreach (ModelError error in ViewData.ModelState[key].Errors)
        //             {
        //                 Errors.Add(error.ErrorMessage);
        //             }
        //         }
        //     }
        //     HttpContext.Session.SetObjectAsJson("Errors", Errors);
        //     // Send back to Register as a Json if it didn't work so we can pass it through via redirect
        //     return RedirectToAction("Profile", new { UserId = NewMessage.MessageRecipientId });
        // }
        // // Post Comment
        // [HttpPost]
        // [Route("LeaveComment")]
        // public IActionResult LeaveComment(CommentValidation NewComment)
        // {
        //     List<string> Errors = new List<string>();
        //     if (ModelState.IsValid)
        //     {
        //         Comment Data = NewComment.ToComment();
        //         Data.CreatedAt = DateTime.Now;
        //         Data.UpdatedAt = DateTime.Now;
        //         _context.Add(Data);
        //         _context.SaveChanges();

        //         return RedirectToAction("Profile", new { UserId = NewComment.ProfileId});
        //     }
        //     else
        //     // If model state fails, it will list errors.
        //     {
        //         // This makes it easier to access the individule errors on html
        //         Dictionary<string, string> Error = new Dictionary<string, string>();
        //         foreach (string key in ViewData.ModelState.Keys)
        //         {
        //             foreach (ModelError error in ViewData.ModelState[key].Errors)
        //             {
        //                 Errors.Add(error.ErrorMessage);
        //             }
        //         }
        //     }
        //     HttpContext.Session.SetObjectAsJson("Errors", Errors);
        //     // Send back to Register as a Json if it didn't work so we can pass it through via redirect
        //     return RedirectToAction("Profile", new { UserId = NewComment.ProfileId });
        // }
    }
}
