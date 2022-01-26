using System;
using SQLite;

namespace MovieLibrary.Models
{
    public class Movie
    { 
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string Mediaformat { get; set; }
    }
}