using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DoorDashAPI.Models
{
    public class Cuisine
    {
        public int CuisineId { get; set; }
        [Required, StringLength(75)]
        public string? CuisineName { get; set; }
        public IList<Restaurant>? Restaurants { get; set; }
    }
}