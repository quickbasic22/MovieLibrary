using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        private ObservableCollection<Movie> items;

        public MockDataStore()
        {
            items = new ObservableCollection<Movie>()
            {
                new Movie { Id = "0", Title = "Pain and Gain", Released=DateTime.Now.AddYears(-7).AddMonths(-3), Mediaformat = "DVD" },
                new Movie { Id = "1", Title = "Jurassic Park", Released=DateTime.Now.AddYears(-12).AddMonths(-11), Mediaformat = "Blueray" },
                new Movie { Id = "2", Title = "Days of Thunder",Released=DateTime.Now.AddYears(-22).AddMonths(7), Mediaformat = "IMAX" },
                new Movie { Id = "3", Title = "Survive The Night",Released=DateTime.Now.AddYears(-2).AddMonths(8), Mediaformat = "UHD" },
                new Movie { Id = "4", Title = "CopShop",Released=DateTime.Parse("1/17/2022"), Mediaformat = "Hd" },
                new Movie { Id = "5", Title = "The Protege", Released=DateTime.Parse("1-15-2022"), Mediaformat = "Blueray" },
                new Movie { Id = "6", Title = "Fortress", Released=DateTime.Parse("1-12-2022"), Mediaformat = "DVD" }
            };
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }


    }
}