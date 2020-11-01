using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        // commented due to implementation of SqlRestaurantData
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
             {
                 new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                 new Restaurant {Id = 2, Name = "Mahatma Gandi", Location = "Delaware", Cuisine = CuisineType.Indian},
                 new Restaurant {Id = 3, Name = "Taco Bell", Location = "New York", Cuisine = CuisineType.Mexican },
                 new Restaurant {Id = 4, Name = "Piregie's", Location = "Illnois", Cuisine = CuisineType.None},
             };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }


        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var result = from r in restaurants
                         where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                         orderby r.Name
                         select r;
            return result;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }


        Restaurant IRestaurantData.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Restaurant IRestaurantData.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Restaurant> IRestaurantData.GetRestaurantsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

