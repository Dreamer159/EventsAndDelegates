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

            /*kostya.Subscribe(netflix);
            kostya.Subscribe(sweetTV);
            lena.Subscribe(netflix);
            olya.Subscribe(netflix);
            anon.Subscribe(netflix);
            anon.Subscribe(sweetTV);

            anon.Unsubscribe(netflix);*/

            netflix.Subscribe(kostya.viewerDelegate);
            netflix.Subscribe(olya.viewerDelegate);
            netflix.Subscribe(anon.viewerDelegate);
            netflix.Subscribe(lena.viewerDelegate);

            sweetTV.Subscribe(kostya.viewerDelegate);
            sweetTV.Subscribe(anon.viewerDelegate);

            netflix.Unsubscribe(anon);

            netflix.NewMovie("Witcher 2", new DateTime(2021, 12, 17), "netflix.com/Witcher%202");
            sweetTV.NewMovie("Love and pigeons", new DateTime(2021, 12, 17), "sweet-tv.com/Love%20and%20pigeons");

            Console.ReadKey();
        }
    }
}