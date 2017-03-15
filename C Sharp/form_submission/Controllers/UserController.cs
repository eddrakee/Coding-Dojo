using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using form_submission.Models;
using Microsoft.AspNetCore.Mvc;

namespace form_submission.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(int age)
        {
            // It creates an instance of our errors list, so when we send errors back they will be stored
            ViewBag.errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(string first, string last, int age, string email, string password ){
            User newUser = new User{
                FirstName = first,
                LastName = last,
                Age = age,
                Email = email,
                Password = password
            };
            if(ModelState.IsValid){
                return RedirectToAction("Success");
            }
            else{
                TryValidateModel(newUser);
                ViewBag.errors = ModelState.Values;
            return View("Index");
            }
            
        }
        [HttpGet]
        [Route("Success")]
        public IActionResult Success(){
            return View();
        }

    }
}
