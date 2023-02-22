using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext dataContext { get; set; }

        public HomeController(MoviesContext someName)
        {
            dataContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewList()
        {
            var movies = dataContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }


        public IActionResult MyPodcast()
        {
            return View();
        }

        public IActionResult BaconSale()
        {
            return Redirect("https://baconsale.com");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = dataContext.categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(ar);
                dataContext.SaveChanges();
                return View("Confirmation", ar);
            }

            else //If Invalid
            {
                ViewBag.Categories = dataContext.categories.ToList();
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = dataContext.categories.ToList();

            var application = dataContext.responses.Single(x => x.ApplicationID == id);

            return View("AddMovie", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            dataContext.Update(blah);
            dataContext.SaveChanges();
            return RedirectToAction("ViewList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var application = dataContext.responses.Single(x => x.ApplicationID == id);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            dataContext.responses.Remove(ar);
            dataContext.SaveChanges();
            return RedirectToAction("ViewList");
        }
    }
}

