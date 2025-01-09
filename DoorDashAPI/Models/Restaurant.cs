using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoorDashAPI.Models;

public record Restaurant
{
    [Key]
    public int RestaurantId { get; init; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Area { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(25)]
    public string State { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public TimeSpan OpeningHour { get; set; }

    [Required, StringLength(50)]
    public TimeSpan ClosingHour { get; set; }

    [Required]
    public bool IsVeg { get; set; }

    public bool? IsOpen { get; set; }

    [Range(0, 5), Column(TypeName = "decimal(2,1)")]
    public decimal? AverageRating { get; set; }

    [StringLength(35)]  
    public string CostForTwo { get; set; } = string.Empty;

    [Required, StringLength(255)]
    public string RestaurantImage { get; set; } = string.Empty;

    [StringLength(255)]
    public string RestaurantLink { get; set; } = string.Empty;

    [Phone, StringLength(20)]
    public string ContactNumber { get; set; } = string.Empty;

    [StringLength(20)]
    public string EstimatedDeliveryTime { get; set; } = string.Empty;
    public ICollection<Dish>? Dishes { get; set; }
    public ICollection<Cuisine>? Cuisines { get; set; }
}
