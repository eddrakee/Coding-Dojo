// Need this for Random num generator
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
// for session
using Microsoft.AspNetCore.Http;
// allows access to the SessionExtensions
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
public static class SessionExtensions{
        public static void SetObjectAsJson(this ISession session, string key, object value){
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key){
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class DojodachiController : Controller
    {   
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HelloKitty Hello = new HelloKitty();
            // Setting Hello to a session object
            HttpContext.Session.SetObjectAsJson("HelloObj", Hello);

            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("/dojodachi")]
        public IActionResult Dojodachi()
        {
            // this retreives everything from the HelloObj in session
            HelloKitty Retrieve = HttpContext.Session.GetObjectFromJson<HelloKitty>("HelloObj");
            // This will pack Retrieve into viewbag.hello
            ViewBag.Hello = Retrieve;
            // this renders to index.cshtml
            return View("Index");
        }

        [HttpGet]
        [Route("/dojodachi/feed")]
        public IActionResult Feed()
        {
            // Pulled out from session and now info is back to being a Hello Kitty object
            HelloKitty Hello = HttpContext.Session.GetObjectFromJson<HelloKitty>("HelloObj");
            Random Rand = new Random();
            if(Hello.Meals < 0){
                Hello.Message = "You don't have any meals! You must work first!";
            }else{
                // If you're not out of meals, you will decrease one meal, then increase fullness by a random number between 5 and 10
                Hello.Meals --;
                Hello.Fullness += Rand.Next(5,11);
            }
                // Now pack it back to session
                HttpContext.Session.SetObjectAsJson("HelloObj", Hello);
                return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("/dojodachi/play")]
        public IActionResult Play()
        {
            // Pulled out from session and now info is back to being a Hello Kitty object
            HelloKitty Hello = HttpContext.Session.GetObjectFromJson<HelloKitty>("HelloObj");
            Random Rand = new Random();
            if(Hello.Energy < 0){
                Hello.Message = "You don't have any Energy! You must rest first!";
            }else{
                // If you're not out of meals, you will decrease one meal, then increase fullness by a random number between 5 and 10
                Hello.Energy -= 5;
                Hello.Happiness += Rand.Next(5,11);
            }
                // Now pack it back to session
                HttpContext.Session.SetObjectAsJson("HelloObj", Hello);
                return RedirectToAction("Dojodachi");
        }
    }
}