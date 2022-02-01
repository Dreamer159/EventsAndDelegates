using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public class TvShowViewer
    {
        public NewMovieHandler viewerDelegate; //delegate which we send to movieService
        public string Name { get; set; }
        public TvShowViewer(string name)
        {
            Name = name;
            viewerDelegate += MovieNotification;
        }
        //method which we add to custom event
        public void MovieNotification(Movie movie)
        {
            Console.WriteLine($"Hello, {Name}! {movie.ReleaseDate} we release movie: '{movie.Title}', go to {movie.Link} to see more details.");
        }
        //method which we add to standart event
        public void MovieNotificationWithArgs(object sender, Movie args)
        {
            Console.WriteLine($"Hello, {Name}! {args.ReleaseDate} we release movie: '{args.Title}', go to {args.Link} to see more details.");
        }

        //subscribe viewer to movieService
        public void Subscribe(MovieService movieService)
        {
            movieService.AddedMovie += MovieNotification;
            movieService.AddedMovieEventHandler += MovieNotificationWithArgs;
        }
        //unsubscribe viewer from movieService
        public void Unsubscribe(MovieService movieService)
        {
            movieService.AddedMovie -= MovieNotification;
            movieService.AddedMovieEventHandler -= MovieNotificationWithArgs;
        }
    }
}
