using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using MovieRental.Models;
using MovieRental.BL;
using MovieRental.Areas.Admin.Models;

namespace MovieRental.Areas.Admin.Controllers
{
    public class BulkLoadController : Controller
    {
        // GET: Admin/BulkLoad
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string movieList, double defaultRentalrate, int defaultQty)
        {
            string[] titles = titles = Regex.Split(movieList, "\r\n|\r|\n");

            List<string> unresolvedTitles = new List<string>();
            List<Movie> resolvedMovie = new List<Movie>();

            foreach(string title in titles)
            {
                Movie m = OMDBService.GetMovieByTitle(title);
                if (m != null)
                {
                    m.RentalRate = defaultRentalrate;
                    m.NoInStock = defaultQty;
                    resolvedMovie.Add(m);
                }
                else
                {
                    if (!string.IsNullOrEmpty(title))
                    {
                        unresolvedTitles.Add(title);
                    }
                }
            }

            BulkLoadOutput blo = new BulkLoadOutput(unresolvedTitles, resolvedMovie);

            TempData["blo"] = blo;
            return View("BulkOutput", blo);
        }
    }
}