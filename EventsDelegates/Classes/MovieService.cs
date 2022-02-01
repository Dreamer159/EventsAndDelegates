using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public delegate void NewMovieHandler(Movie jfonqwfdopnpasdf); //delegate for custom event
    public class MovieService
    {
        public event EventHandler<Movie> AddedMovieEventHandler; //standart event ()
        public event NewMovieHandler AddedMovie; // custom event
        public string Title { get; set; }
        public string Link { get; set; }
        private IEnumerable<Movie> Movies { get; set; } = new List<Movie>();

        //Create new movie and invoke events
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
            foreach(Movie movie in Movies)

                AddedMovie.DynamicInvoke
        }

        //subscribe viewer using custom event and delegate
        public void Subscribe(NewMovieHandler handler)
        {
            AddedMovie += handler;
        }
        //unsubscribe viewer using custom event and delegate
        public void Unsubscribe(NewMovieHandler handler)
        {
            AddedMovie -= handler;
        }
    }
}