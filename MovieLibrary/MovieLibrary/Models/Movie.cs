using System;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public DateTime Released 
        {
            get;
            set;
        }
        public string Mediaformat 
        {
            get;
            set;
        }
               
    }
}