using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public delegate void NewMovieHandler(Movie movie);
    public class MovieService
    {
        public event EventHandler<Movie> AddedMovieEventHandler;
        public event NewMovieHandler AddedMovie;
        public string Title { get; set; }
        public string Link { get; set; }
        private IEnumerable<Movie> Movies { get; set; } = new List<Movie>();

        public void NewMovie(string title, DateTime date, string link)
        {
            Movie movie = new Movie
            {
                Title = title,
                ReleaseDate = date,
                Link = link,
            };
            Movies.Append(movie);
            Console.WriteLine("Custom event");
            if(AddedMovie != null)
                AddedMovie(movie);
            Console.WriteLine();
            Console.WriteLine("Event<EventHandler>");
            EventHandler<Movie> handler = AddedMovieEventHandler;
            handler?.Invoke(this, movie);
            Console.WriteLine();
        }

        public void Subscribe(NewMovieHandler handler)
        {
            AddedMovie += handler;
        }
        public void Unsubscribe(NewMovieHandler handler)
        {
            AddedMovie -= handler;
        }
    }
}