using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication{
    public class DemoController : Controller {

        [HttpGet]
        [Route("")]
        public string Index() {
            return "Welcome!";
        }

        [HttpGet]
        [Route("Card/myFavoriteNumber")]
        public int FavoriteNumber() {
            return 666;
        }

        [HttpGet]
        [Route("helloWorld")]
        public ViewResult helloWorld() {
            return View("Index");
        }



        [HttpGet]
        [Route("Card/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public IActionResult ShowTemplate(string FirstName, string LastName, string Age, string FavoriteColor) {
            System.Console.WriteLine(FirstName);
            object callingCard = new {
                MyFirstName = FirstName,
                MyLastName = LastName,
                MyAge = Age,
                MyColor = FavoriteColor,
            };
            return Json(callingCard);
        }
        
    }
}