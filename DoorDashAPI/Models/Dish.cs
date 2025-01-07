using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoorDashAPI.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    public int RestaurantId { get; set; } // for many to one relation

    [Required, StringLength(30)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(255)]
    public string Description { get; set; } = string.Empty;

    [Required, Range(0.02, 9999.99), Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public bool IsVeg { get; set; }

    [MaxLength(255)]
    public string DishImg { get; set; } = string.Empty;

    [Range(0, 5), Column(TypeName = "decimal(2,1)")]
    public decimal Rating { get; set; }

    [JsonIgnore]
    public Restaurant? Restaurant { get; set; }
}
