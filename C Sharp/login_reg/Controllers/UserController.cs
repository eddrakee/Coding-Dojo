using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using login_reg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace login_reg.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // NEED TO FINISH CONNECTING SECURELY

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.RegErrors = new List<string>();
            ViewBag.LogError = "";
            return View();
        }

        // Post for /Register
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user){
            // This will do two things: 1. It will map the names on index.html form to the model validation fields/Data validations 2. the second "user" is the name that we are calling for the new User instance. This way we don't have to build User user = new User etc down here and pass in every individual data validation things like (string FirstName, string LastName ....)
            // Since we are doing it this way, we dont need a TryValidateModel for this

            if(ModelState.IsValid){
                // This is where you would put check if user exists filter here

                // Test with System.Console.WriteLine("Everything is groovy!");
                // to test this, you may need to change View to redirect Index

                // Will add hashing later in the future 

                // if valid, you want to create a new User
                // Also since we passed everything in how it was named in the model, we need to use the same names and not whats on the index form
                string QueryString = $"INSERT INTO Users (FirstName, LastName, Email, Password, Created_At) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', NOW())";
                _dbConnector.Execute(QueryString);

                string Query = "SELECT * from Users order by UserId desc limit 1";
                Dictionary<string, object> MyUser = _dbConnector.Query(Query).SingleOrDefault();
                HttpContext.Session.SetInt32("SessionID", (int)MyUser["UserId"]);

                // Upon success of a Post, redirect
                return RedirectToAction("Success");
            }
            else{
                // To test: System.Console.WriteLine("Error!");
                ViewBag.RegErrors = ModelState.Values;
                ViewBag.LogError = "";
                return View("Index");
            }
            
        }
        // Login Route
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password){

            string Query = $"SELECT * FROM Users WHERE Email = '{Email}'";
            Dictionary<string, object> MyUser = _dbConnector.Query(Query).SingleOrDefault();
            
            if(MyUser != null && Password != null ){
                // line above asks if a user was brought back and if a password was typed in
                if((string)MyUser["Password"] == Password){
                    // Use brackets to unpack dictionaries
                    // yay it matches!
                    // Need to store in session...
                    // List<object> UserData = new List<object>();

                    // HttpContext.Session.SetObjectAsJson("SessionInfo", UserData);
                    // List<object> Retrieve = HttpContext.Session.GetObjectFromJson<List<object>>("SessionInfo");
                    HttpContext.Session.SetInt32("SessionID", (int)MyUser["UserId"]);
                    return RedirectToAction("Success");
                }
                
            }
            ViewBag.LogError = "Invalid Combination!";
            ViewBag.RegErrors = new List<string>();
            return View("Index");

        }
        // Success Route
        [HttpGet]
        [Route("Success")]
        public IActionResult Success(){
            int? userid = HttpContext.Session.GetInt32("SessionID");
            string Query = $"SELECT * FROM Users WHERE UserId = {userid}";
            Dictionary<string, object> MyUser = _dbConnector.Query(Query).SingleOrDefault();
            ViewBag.MyUser = MyUser;
            return View();
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
           HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}