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
            List<Friend>AllFriends = _context.Friends.Where( f => f.InviteReceivedId == CurrentUser.UserId)
                .ToList();
            List<Friend>AllInvites = _context.Friends.Where( f => f.InviteSentFromId != CurrentUser.UserId )
                .ToList();
            ViewBag.InviteList =  AllInvites;
            ViewBag.FriendList =  AllFriends;
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
        // ADD FRIEND
        [HttpPost]
        [RouteAttribute("AddFriend")]
        public IActionResult AddFriend(FriendValidation NewFriend)
        {
            List<string> Errors = new List<string>();
            if (ModelState.IsValid)
            {
                Friend Data = NewFriend.ToFriend();
                Data.CreatedAt = DateTime.Now;
                Data.UpdatedAt = DateTime.Now;
                _context.Add(Data);
                _context.SaveChanges();
                return View("Dashboard");
                // return RedirectToAction("Profile", new { UserId = NewFriend.MessageRecipientId});
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
            return View("Dashboard");
            // return RedirectToAction("Profile", new { UserId = New.MessageRecipientId });
        }
    }
}
