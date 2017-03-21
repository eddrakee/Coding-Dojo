using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
{
    public class BankController : Controller
    {
        private BankContext _context;
        public BankController(BankContext context)
        {
            _context = context;
        }
        [HttpGet]
        [RouteAttribute("Main")]
        public IActionResult Main(){
            // Grabbing current session User Id
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            // This will grab the current user as a complete user Object
            User CurrentUser = _context.Users.Where(u => u.UserId == UserId).SingleOrDefault();
            ViewBag.User = CurrentUser;

            // This pulls all the Transaction data and filters it by the current User
            List<Transaction> AllTransactions = _context.Transactions.Where( t => t.Users_UserId == CurrentUser.UserId).ToList();
            ViewBag.AllTransactions = AllTransactions;
            return View("AccountPage");
        }
        
    }
}
