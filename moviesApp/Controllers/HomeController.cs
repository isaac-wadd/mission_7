
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using moviesApp.Models;

namespace moviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieCtxt _movieCtxt { get; set; }

// constructor for home controller obj
        public HomeController(ILogger<HomeController> logger, MovieCtxt movCtxt) {
            _logger = logger;
            _movieCtxt = movCtxt;
        }

        public IActionResult Index() { return View(); }

        public IActionResult Privacy() { return View(); }

        [HttpGet]
        public IActionResult Movie() {
            ViewBag.categories = _movieCtxt.categories.ToList();
            ViewBag.ratings = _movieCtxt.ratings.ToList();
            ViewBag.movieViewCtxt = "Add";
            ViewBag.movieFormCtxt = "Movie";
            return View();
        }

        [HttpPost]
        public IActionResult Movie(Movie mov) {
            if (ModelState.IsValid) {
                ViewBag.userAction = "addition was";
                _movieCtxt.Add(mov);
                _movieCtxt.SaveChanges();
                return View("Confirmation");
            }
            else {
                ViewBag.categories = _movieCtxt.categories.ToList();
                ViewBag.ratings = _movieCtxt.ratings.ToList();
                ViewBag.movieViewCtxt = "Add";
                ViewBag.movieFormCtxt = "Movie";
                return View(mov);
            }
        }

        [HttpGet]
        public IActionResult MoviesList() {
            var mvs = _movieCtxt.movies.Include(x => x.category).Include(x => x.rating).ToList();
            return View(mvs);
        }

        public IActionResult Podcasts() { return View(); }

        public IActionResult Bacon() { return Redirect("https://baconsale.com/"); }

        [HttpGet]
        public IActionResult Edit(int movieID) {
            ViewBag.categories = _movieCtxt.categories.ToList();
            ViewBag.ratings = _movieCtxt.ratings.ToList();
            ViewBag.movieViewCtxt = "Edit";
            ViewBag.movieFormCtxt = "Edit";
            var mov = _movieCtxt.movies.Single(x => x.movieID == movieID);
            return View("Movie", mov);
        }

        [HttpPost]
        public IActionResult Edit(Movie mov) {
            if (ModelState.IsValid) {
                ViewBag.userAction = "edits were";
                _movieCtxt.Update(mov);
                _movieCtxt.SaveChanges();
                return View("Confirmation");
            }
            else {
                ViewBag.categories = _movieCtxt.categories.ToList();
                ViewBag.ratings = _movieCtxt.ratings.ToList();
                return View(mov);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieID) {
            var mov = _movieCtxt.movies.Single(x => x.movieID == movieID);
            return View("DeleteConfirm", mov);
        }

        [HttpPost]
        public IActionResult Delete(Movie mov) {
            _movieCtxt.movies.Remove(mov);
            _movieCtxt.SaveChanges();
            return RedirectToAction("MoviesList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
