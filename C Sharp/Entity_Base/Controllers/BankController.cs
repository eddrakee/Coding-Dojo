using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
            // Try Catch for errors list
            List<string> Errors = new List<string>();
            // Use a try catch - it will try to pull from session and if it throws an expection, it will go to catch instead of breaking code
            try
            {
                // When it comes back from session, it will be a list of objects.
                List<string> Results = HttpContext.Session.GetObjectFromJson<List<string>>("Errors");
                // to make sure they are strings, cast them as strings and put them in Errors
                foreach (object error in Results)
                {
                    Errors.Add(error.ToString());
                }
            }
            catch
            {
                // We don't want it to do anything if there is something wrong.
            }
            // Either a list of strings or nothing, but we can iterate through either
            ViewBag.Errors = Errors;
        
            // This will grab the current user as a complete user Object
            // This finds the user object and all of the associated transactions
            User CurrentUser = _context.Users
            .Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId"))
            .SingleOrDefault();

            // Creating a new list of Transctions that is sorted. Like a manual include
            List<Transaction> Transactions = _context.Transactions.Where(t => t.UserId == CurrentUser.UserId)
            .OrderByDescending(d => d.Date).ToList();
            // Putting this list into current user transactions field
            CurrentUser.Transactions = Transactions;
            // Cant use a .include after a SingleOrDefault. You have to query the user. Include what you want and then .single
            // This clears the Transaction variable after use
            Transactions = null;
            ViewBag.User = CurrentUser;

            // This pulls all the Transaction data and filters it by the current User
            // List<Transaction> AllTransactions = _context.Transactions.Where( t => t.Users_UserId == CurrentUser.UserId).ToList();
            // ViewBag.AllTransactions = AllTransactions;

            return View("AccountPage");
        }
        [HttpPost]
        [RouteAttribute("AddTransaction")]
        public IActionResult AddTransaction( Transaction NewTransaction ){
            // This grabs the current user's total object
            User CurrentUser = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("UserId")).SingleOrDefault();
            // Create an errors list
            List<string> Errors = new List<string>();
            if (NewTransaction.Amount == null)
            {
                // Add a new if statement for each validation
                Errors.Add("Please add an amount!");
            }
            if(CurrentUser.Balance + NewTransaction.Amount < 0){
                // If try to withrdaw more than they own
                Errors.Add("You don't have enough money!");
            }
            if(Errors.Count == 0){
                // If no errors, add to db
                NewTransaction.CreatedAt = DateTime.Now;
                NewTransaction.Date = DateTime.Now;
                NewTransaction.UpdatedAt = DateTime.Now;
                // It already knows which table to add to, but you can add the table name
                _context.Transactions.Add(NewTransaction);
                CurrentUser.Balance += NewTransaction.Amount; 
                _context.SaveChanges();
            }
            else{
                // Puts the list of errors into session 
                HttpContext.Session.SetObjectAsJson("Errors", Errors);
            }
            return RedirectToAction("Main");
        }


        
    }
}
