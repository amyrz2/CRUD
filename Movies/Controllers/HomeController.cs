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

        // index controller that returns view
        public IActionResult Index()
        {
            return View();
        }

        // view all the movies alphabetical by title 
        public IActionResult ViewList()
        {
            var movies = dataContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        // returns view with link to podcast
        public IActionResult MyPodcast()
        {
            return View();
        }

        // BaconSale returns to podcast link
        public IActionResult BaconSale()
        {
            return Redirect("https://baconsale.com");
        }

        // get controller that will list out all the categories and return form
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = dataContext.categories.ToList();

            return View();
        }

        // after user submits, data is added and saved to the db and confirmation page is returned
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

        // when user wants to edit a movie, identifies movie by applicationID and displays data in the form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = dataContext.categories.ToList();

            var application = dataContext.responses.Single(x => x.ApplicationID == id);

            return View("AddMovie", application);
        }

        // user clicks save and the row is updated and changes are saved. Brings user back to list of movies 
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            dataContext.Update(blah);
            dataContext.SaveChanges();
            return RedirectToAction("ViewList");
        }

        // Displays page confirming user wants to delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var application = dataContext.responses.Single(x => x.ApplicationID == id);

            return View(application);
        }

        // movie is removed from db and user is brough back to full list of movies
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            dataContext.responses.Remove(ar);
            dataContext.SaveChanges();
            return RedirectToAction("ViewList");
        }
    }
}

