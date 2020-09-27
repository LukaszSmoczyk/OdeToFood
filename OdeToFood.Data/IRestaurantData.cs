using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CusineType.Italian},
                new Restaurant {Id = 2, Name = "Mahatma Gandi", Location = "Delaware", Cuisine = CusineType.Indian},
                new Restaurant {Id = 3, Name = "Taco Bell", Location = "New York", Cuisine = CusineType.Mexican },
                new Restaurant {Id = 4, Name = "Piregie's", Location = "Illnois", Cuisine = CusineType.None},
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var result = from r in restaurants
                         where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                         orderby r.Name
                         select r;
            return result;
        }
    }
}
