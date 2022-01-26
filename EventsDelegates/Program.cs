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
            TvShowViewer kostya = new TvShowViewer() { Name = "Kostya" };
            TvShowViewer lena = new TvShowViewer() { Name = "Lena" };
            TvShowViewer olya = new TvShowViewer() { Name = "Olya" };
            TvShowViewer anon = new TvShowViewer() { Name = "Anon" };

            netflix.Subscribe(kostya);
            netflix.Subscribe(lena);
            netflix.Subscribe(olya);
            netflix.Subscribe(anon);

            sweetTV.Subscribe(kostya);
            sweetTV.Subscribe(anon);

            netflix.Unsubscribe(anon);

            netflix.NewMovie("Witcher 2", new DateTime(2021, 12, 17), "netflix.com/Witcher%202");
            sweetTV.NewMovie("Love and pigeons", new DateTime(2021, 12, 17), "sweet-tv.com/Love%20and%20pigeons");
        }
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}