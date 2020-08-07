using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood2.Core;
using OdeToFood2.Data;

namespace OdeToFood2.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        //Output Models
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        //Use this property a a input/Output model
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
             
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}