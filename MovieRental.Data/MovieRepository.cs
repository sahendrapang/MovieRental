﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieRepository
    {
        MovieRentalContext db = new MovieRentalContext();

        public Movie GetMovie(string id)
        {
            return db.Movies.Single(m => m.MovieID == id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies;
        }

        public void Add(Movie movie)
        {
            for (int i = 0; i < movie.Genres.Count; i++)
            {
                string gendreDescription = movie.Genres[i].Description;
                Genre existingGenre = db.Genres.SingleOrDefault(e => e.Description == gendreDescription);

                if (existingGenre != null)
                {
                    movie.Genres[i] = existingGenre;
                }  
            }
            db.Movies.Add(movie);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return db.Genres;
        }

        public void Delete(string id)
        {
            Movie movie = db.Movies.Single(x => x.MovieID == id);

            db.Movies.Remove(movie);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Movie> FindMoviesByTitle(string Title)
        {
            return db.Movies.Where(m => m.Title.ToLower().Contains(Title));
        }
    }
}
