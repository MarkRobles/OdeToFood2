using OdeToFood2.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood2.Data
{
   public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();

    }
}
