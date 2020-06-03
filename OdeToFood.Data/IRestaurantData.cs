using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string nombre);
        Restaurant GetById(int Id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant NewRestaurant);

        int Commit();

    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Nombre="Empanadas Con Grasa", Ubicacion="Calle principal",Cocina=TipoDeCocina.Criolla},
                new Restaurant{Id=2,Nombre="Empanadas Con Grasa", Ubicacion="Calle principal",Cocina=TipoDeCocina.Criolla},
                new Restaurant{Id=3,Nombre="Empanadas Con Grasa", Ubicacion="Calle principal",Cocina=TipoDeCocina.Criolla}

            };

        }
        public Restaurant GetById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Nombre = updatedRestaurant.Nombre;
                restaurant.Ubicacion = updatedRestaurant.Ubicacion;
                restaurant.Cocina = updatedRestaurant.Cocina;
                
            }
            return restaurant;
        }
        public Restaurant Add(Restaurant newrestaurant)
        {
            restaurants.Add(newrestaurant);
            newrestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return newrestaurant;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string nombre = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(nombre) || r.Nombre.StartsWith(nombre)

                   orderby r.Nombre
                   select r;
        }


    }
}
