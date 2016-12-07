using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototypeAdal4.Data;
using PrototypeAdal4.Models.ReleaseViewModels;


namespace PrototypeAdal4.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrototypeAdal4Context _context;

        public HomeController(PrototypeAdal4Context context)
        {
            _context = context;
        }

        public async Task<ActionResult> About()
        {
            IQueryable<ReleaseDateGroup> data = from product in _context.Products
                group product by product.SubmissionDate
                into dateGroup
                select new ReleaseDateGroup()
                {
                    SubmissionDate = dateGroup.Key,
                    ReleaseCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
