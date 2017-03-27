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
            // Find all invites for a specific user
            List<Invite> AllPendingInvites = _context.Invites.Where(u => u.InviteReceivedId == CurrentUser.UserId)
                .Include(u => u.InviteReceived)
                .ToList();
            ViewBag.AllPendingInvites = AllPendingInvites;
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
            List<User> AllUsersMinusMe = _context.Users.Where(b => b.UserId != CurrentUser.UserId)
                .Include(u => u.InviteInvitesReceived)
                .Include(u => u.InviteInvitesSent)
                .ToList();
            ViewBag.User = CurrentUser;
            ViewBag.AllUsersMinusMe = AllUsersMinusMe;
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
        // ADD Invite - GET
        [HttpGet]
        [RouteAttribute("AddInvite/{UserId}")]
        public IActionResult AddInvite(int UserId)
        {
            int? getUserId = HttpContext.Session.GetInt32("UserId");
            Invite newInvite = new Invite(){
                InviteSentFromId = (int)getUserId,
                InviteReceivedId = UserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Accepted = false
            };
            _context.Add(newInvite);
            _context.SaveChanges();
            return RedirectToAction("AllUsers");
        }
        // ADD FRIEND - GET
        [HttpGet]
        [RouteAttribute("AddFriend/{UserId}")]
        public IActionResult AddFriend(int UserId)
        {
            int? getUserId = HttpContext.Session.GetInt32("UserId");
            Invite AddConnection = _context.Invites.SingleOrDefault(u => u.InviteReceivedId == getUserId);
            AddConnection.Accepted = true;
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
       
        
    }
}
