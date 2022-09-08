using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfiseeDemo.Data;
using ProfiseeDemo.Models;

namespace ProfiseeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfiseeDemoContext _context;

        public HomeController(ProfiseeDemoContext context)
        {
            _context = context;
        }

      

        private readonly ILogger<HomeController> _logger;

  

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalesPersonal()
        {
            return View();
        }
        public IActionResult Sales()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }

        public async Task<IActionResult> QuarterlySales()
        {
            return _context.Sales != null ?
                       View(await _context.Sales.ToListAsync()) :
                       Problem("Entity set 'ProfiseeDemoContext.Sales'  is null.");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }

     


    }
}