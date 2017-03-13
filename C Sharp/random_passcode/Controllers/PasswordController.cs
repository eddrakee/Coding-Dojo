// Need this for Random num generator
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
// for session
using Microsoft.AspNetCore.Http;

namespace Password.Controllers
{
    public class PasswordController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(string passnum)
        {
            if (passnum == null){
                passnum = "";
            }
            // This will increase/manage the counter
            // NOTE: int? is a nullable int
            int? Counter = HttpContext.Session.GetInt32("Counter");
            if(Counter == null){
                HttpContext.Session.SetInt32("Counter", 0);
            }

            // Packing into ViewBag
            ViewBag.Counter = Counter;
            ViewBag.Password = passnum;

            return View();
        }
        
        [HttpPost]
        [RouteAttribute("/generate")]
        public IActionResult Generate(){
            int Counter = (int)HttpContext.Session.GetInt32("Counter");
            HttpContext.Session.SetInt32("Counter", Counter+1);

             // This will generate the passcode
            string PossibleNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string Password = "";
            Random Rand = new Random();
            for (int i = 0; i <15; i ++){
                Password = Password + PossibleNum[Rand.Next(0, PossibleNum.Length)];
            }

            return RedirectToAction("Index", new { passnum = Password});
        }
    }
}