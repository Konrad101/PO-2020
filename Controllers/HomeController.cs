<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_implementacja_StudiaPodyplomowe.Models;
using System;
=======
>>>>>>> InitializingDatabase
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using PO_implementacja_StudiaPodyplomowe.Models.Database;
>>>>>>> InitializingDatabase

namespace PO_implementacja_StudiaPodyplomowe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
