using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DoorDashAPI.Models
{
    public record Cuisine
    {
        [Key]
        public int CuisineId { get; init; }

        [Required, StringLength(75)]
        public string? CuisineName { get; set; }


        [JsonIgnore]
        public Restaurant? Restaurant { get; init; }

        [JsonIgnore]
        public int RestaurantId { get; init; }

    }
}