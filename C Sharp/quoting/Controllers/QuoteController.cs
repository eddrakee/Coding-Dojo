using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using quoting.Models;

namespace quoting.Controllers
{
    public class QuoteController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }
        // Create Quote 
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Quote newQuote)
        {
            if(ModelState.IsValid){
                // If no errors...
                string QueryString = $"INSERT INTO quotes (author, content, created_at) VALUES('{newQuote.author}', '{newQuote.content}', NOW())";
                DbConnector.Execute(QueryString);
                return RedirectToAction("Quote");
            }else{
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
            
        }
        // View All Quotes Page
        [HttpGet]
        [RouteAttribute("Quote")]
        public IActionResult Quote(){
            List<Dictionary<string, object>> quotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.quotes = quotes;

            return View("Quote");
        }
        
    }
}


