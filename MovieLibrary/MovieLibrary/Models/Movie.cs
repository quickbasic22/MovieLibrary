using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace MovieLibrary.Models
{
    public class Movie : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public string Id
        {
            get => Id;
            set => Id = value;
        }
        public string Title
        {
            get => Title;
            set => Title = value;
        }
        public DateTime Released 
        {
            get => Released;
            set => Released = value;
        }
        public string Mediaformat 
        {
            get => Mediaformat;
            set => Mediaformat = value;
        }
        public bool MovieIsSelected 
        {
            get => MovieIsSelected;
            set => MovieIsSelected = value; 
        }


        #region INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}