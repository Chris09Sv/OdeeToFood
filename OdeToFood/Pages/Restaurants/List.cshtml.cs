using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IRestaurantData RestaurantData { get; }

        public ListModel(IConfiguration config,IRestaurantData restaurantData)
        {
            this.config = config;
            RestaurantData = restaurantData;
        }
        public void OnGet()
        {
            //proveee informacion sobre la transaccion http
            Message = "#StayAtHome";
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}