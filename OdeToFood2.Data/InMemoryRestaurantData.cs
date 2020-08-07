using OdeToFood2.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood2.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant {  Id= 1, Name = "Marcos Pizza", Cuisine= CuisineType.Italian, Location="Italia"},
                new Restaurant {  Id= 2, Name = "Mariana Sushi", Cuisine= CuisineType.Japanese, Location="Japon"},
                new Restaurant {  Id= 3, Name = "Tacos Ely", Cuisine= CuisineType.Mexican, Location="Mexico"}
             };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToUpper().Contains(name.ToUpper())
                   orderby r.Name
                   select r;
        }


        public Restaurant GetById(int id) {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant) {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null) {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }


        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit() {
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
    }
}
