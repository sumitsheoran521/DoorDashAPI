using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DoorDashAPI.Models
{
    public class RestaurantCuisine
    {
        public int RestaurantId { get; set; }

        public int CuisineId { get; set; }

        public Restaurant? Restaurant { get; set; }
        public Cuisine? Cuisine { get; set; }
    }
}





