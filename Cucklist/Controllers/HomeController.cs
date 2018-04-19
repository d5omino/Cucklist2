using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cucklist.Models;
using Cucklist.Data;

namespace Cucklist.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["images"] = new List<Image>(_context.Image.ToList());
            ViewData["videos"] = new List<Video>(_context.Video.ToList());
            ViewData["clips"] = new List<Clip>(_context.Clip.ToList());

            return View();
        }


    }
}
