using System;
using SQLite;

namespace MovieLibrary.Models
{
    public class Movie
    {
        private static int id = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string Mediaformat { get; set; }
        public Movie()
        {
            Id = id++;
        }
    }
}