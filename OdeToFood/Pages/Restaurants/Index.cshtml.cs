using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IRestaurantData RestaurantData { get; }

             public IndexModel(IConfiguration config,IRestaurantData restaurantData)
        {
            this.config = config;
            RestaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = "#StayAtHome";
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);

        }
    }
}