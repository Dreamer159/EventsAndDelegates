using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public class TvShowViewer
    {
        public NewMovieHandler viewerDelegate;
        public string Name { get; set; }
        public TvShowViewer(string name)
        {
            Name = name;
            viewerDelegate += MovieNotification;
        }
        public void MovieNotification(Movie movie)
        {
            //id потока в котором вызвался метод
            //Thread thread = Thread.CurrentThread;
            Console.WriteLine($"Hello, {Name}! {movie.ReleaseDate} we release movie: '{movie.Title}', go to {movie.Link} to see more details.");
        }

        public void Subscribe(MovieService movieService)
        {
            movieService.AddedMovie += MovieNotification;
        }
        public void Unsubscribe(MovieService movieService)
        {
            movieService.AddedMovie += MovieNotification;
        }
    }
}
