using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5CRUD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5CRUD.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext mvContext { get; set; }

        //Constructor
        public HomeController( MovieContext someName)
        {
            mvContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieInput()
        {
            ViewBag.Categories = mvContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieInput(MovieModel mm)
        {
            if (ModelState.IsValid)
            {
                mvContext.Add(mm);
                mvContext.SaveChanges();

                return View("Confirmation", mm);
            }
            else
            {
                ViewBag.Categories = mvContext.Categories.ToList();

                return View(mm);
            }

        }

        [HttpGet]
        public IActionResult MovieList ()
        {
            var inputs = mvContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(inputs);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = mvContext.Categories.ToList();

            var movie = mvContext.Responses.Single(x => x.MovieID == movieid);

            return View("MovieInput", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel blah)
        {
            mvContext.Update(blah);
            mvContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = mvContext.Responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (MovieModel blah)
        {
            mvContext.Responses.Remove(blah);
            mvContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
