using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NAMESPACE.Models;
using System.Linq;

namespace NAMESPACE.Controllers
{
    public class HomeController : Controller
    {
        private BaseContext _context;
        public HomeController(BaseContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
