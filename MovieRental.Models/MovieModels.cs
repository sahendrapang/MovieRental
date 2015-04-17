using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieRental.Models
{
    [MetadataType(typeof(MovieMetaData))]
    public class Movie
    {
        [Key][Required]
        public string MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string FilmRating { get; set; }
        public string Language { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        private List<Genre> genres = new List<Genre>();

        public List<Genre> Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        [Required]
        public int NoInStock { get; set; }
        [Required]
        public double RentalRate { get; set; }
        public string ImdbRating { get; set; }
    }

    public class Genre
    {
        public Genre(){ }
        public Genre(string Description)
        {
            this.Description = Description; 
        }

        [Key]
        public string Description { get; set;}
        private List<Movie> movies = new List<Movie>();

        public virtual List<Movie> Movies
        {
            get { return movies; }
        }
    }

    public class MovieMetaData
    {
        [Required(ErrorMessage = "Movie ID is required")]
        [DisplayName("ID")]
        [RegularExpression(@"[a-z]{2}\d{7}$", ErrorMessage = "The format should be 2 lowercase letter followed with 7 digit")]
        public string MovieID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [DisplayName("Year")]
        [RegularExpression(@"\d{4}$")]
        public string ReleaseYear { get; set; }
        [DisplayName("Classification")]
        public string FilmRating { get; set; }
        public string Language { get; set; }
        [DisplayName("Poster URL")]
        [Required(ErrorMessage = "Poster  URL is required")]
        public string Poster { get; set; }
        [DataType(DataType.MultilineText)]
        public string Plot { get; set; }

        private List<Genre> genres = new List<Genre>();

        public List<Genre> Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        [Required(ErrorMessage = "No in Stock is required")]
        [DisplayName("No in Stock")]
        public int NoInStock { get; set; }
        [Required(ErrorMessage = "Rental Rate is Required")]
        [DisplayName("Rental Rate")]
        public double RentalRate { get; set; }
        public string ImdbRating { get; set; }
    }
}
