using System;
using SQLite;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public string Id { get; set; } = "7";
        public string Title { get; set; }
        public DateTime Released { get; set; } = DateTime.Now;
        public string Mediaformat { get; set; } = "DVD";
    }
}