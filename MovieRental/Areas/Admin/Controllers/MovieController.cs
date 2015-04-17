﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        MovieRepository rep = new MovieRepository();
        // GET: Admin/Movie
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = rep.GetAllMovies();
            return View(movies);
        }

        // GET: Admin/Movie/Details/5
        public ActionResult Details(string id)
        {
            Movie movie = rep.GetMovie(id);
            return View(movie);
        }

        // GET: Admin/Movie/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        // POST: Admin/Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                rep.Add(movie);
                rep.Save();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Admin/Movie/Edit/5
        public ActionResult Edit(string id)
        {
            Movie movie = rep.GetMovie(id);
            return View(movie);
        }

        // POST: Admin/Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Movie movie = rep.GetMovie(id);
                UpdateModel(movie);

                rep.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Movie/Delete/5
        public ActionResult Delete(string id)
        {
            return View(rep.GetMovie(id));
        }

        // POST: Admin/Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                rep.Delete(id);
                rep.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
