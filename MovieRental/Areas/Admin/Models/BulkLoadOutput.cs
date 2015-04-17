using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.Areas.Admin.Models
{
    public class BulkLoadOutput
    {
        public BulkLoadOutput(List<string> unresolveTitles, List<Movie> resolvedMovie)
        {
            UnresolveTitles = unresolveTitles;
            ResolvedMovie = resolvedMovie;
        }

        public List<string> UnresolveTitles { get; set; }
        public List<Movie> ResolvedMovie { get; set; }
    }
}