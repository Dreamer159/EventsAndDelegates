﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates.Classes
{
    public class TvShowViewer
    {
        public string Name { get; set; }
        public void MovieNotification(Movie movie)
        {
            Console.WriteLine($"Hello, {Name}! {movie.ReleaseDate} we release movie: '{movie.Title}', go to {movie.Link} to see more details.");
        }
    }
}
