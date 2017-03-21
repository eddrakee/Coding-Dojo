using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class UserController : Controller
    {
        private BankContext _context;
        public UserController(BankContext context)
        {
            _context = context;
        }
        
    }
}
