using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditarModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; } 
        public IEnumerable<SelectListItem> Cocinas { get; set; }
        public EditarModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? Id)
        {
            Cocinas = htmlHelper.GetEnumSelectList<TipoDeCocina>();
            if (Id.HasValue)
            {
                Restaurant = restaurantData.GetById(Id.Value);

            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cocinas = htmlHelper.GetEnumSelectList<TipoDeCocina>();
                return Page();
            }
            if (Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Add(Restaurant);

            }
            restaurantData.Commit();
            TempData["Message"] = " Restaurant Guardado!";
            return RedirectToPage("Detalles", new { Id = Restaurant.Id });


        }

    }
}