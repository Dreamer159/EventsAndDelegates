using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public delegate void MovieServiceHandler(Movie movie);
    public class MovieService
    {
        public event MovieServiceHandler AddedMovie;
        public string Title { get; set; }
        public string Link { get; set; }
        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();

        public void NewMovie(string title, DateTime date, string link)
        {
            Movie movie = new Movie
            {
                Title = title,
                ReleaseDate = date,
                Link = link,
            };
            Movies.Append(movie);
            AddedMovie?.Invoke(movie);
            Console.WriteLine();
        }
        public void Subscribe(TvShowViewer viewer)
        {
            AddedMovie += viewer.MovieNotification;
        }
        public void Unsubscribe(TvShowViewer viewer)
        {
            AddedMovie -= viewer.MovieNotification;
        }
    }
}