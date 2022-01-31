using EventsDelegates.Classes;

namespace EventsDelegates
{
    public delegate void HandlerDelegate(object sender, EventArgs e);
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieService netflix = new MovieService()
            {
                Title = "Netflix",
                Link = "netflix.com",
            };
            MovieService sweetTV = new MovieService()
            {
                Title = "Sweet TV",
                Link = "sweet-tv.com",
            };
            TvShowViewer kostya = new TvShowViewer("Kostya");
            TvShowViewer lena = new TvShowViewer("Lena");
            TvShowViewer olya = new TvShowViewer("Olya");
            TvShowViewer anon = new TvShowViewer("Anon");

            netflix.AddedMovie += kostya.MovieNotification;
            netflix.AddedMovieEventHandler += kostya.MovieNotificationWithArgs;
            netflix.Subscribe(olya.viewerDelegate);
            lena.Subscribe(netflix);

            sweetTV.Subscribe(kostya.viewerDelegate);
            anon.Subscribe(sweetTV);

            anon.Unsubscribe(netflix);

            Console.WriteLine("Adding new movie to Netflix");
            netflix.NewMovie("Witcher 2", new DateTime(2021, 12, 17), "netflix.com/Witcher%202");
            Console.WriteLine();
            Console.WriteLine("Adding new movie to Sweet TV");
            sweetTV.NewMovie("Love and pigeons", new DateTime(2021, 12, 17), "sweet-tv.com/Love%20and%20pigeons");

            Console.ReadKey();
        }
    }
}