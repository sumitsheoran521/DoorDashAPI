using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoorDashAPI.Models;

public partial class Restaurant
{
    [Key]
    public int RestaurantId { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Area { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(25)]
    public string State { get; set; } = string.Empty;

    [Phone, StringLength(20)]
    public string ContactNumber { get; set; } = string.Empty;

    [Required]
    public bool IsVeg { get; set; }

    public bool? IsOpen { get; set; } // This will be dynamically updated

    [Range(0, 5), Column(TypeName = "decimal(2,1)")]
    public decimal? AverageRating { get; set; }

    [StringLength(35)]  
    public string CostForTwo { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public TimeSpan OpeningHour { get; set; }
    public TimeSpan ClosingHour { get; set; }

    [Required, StringLength(255)]
    public string RestaurantImage { get; set; } = string.Empty;

    [StringLength(255)]
    public string RestaurantLink { get; set; } = string.Empty;

    [StringLength(20)]
    public string EstimatedDeliveryTime { get; set; } = string.Empty;

    public IList<Cuisine>? Cuisines { get; set; }
    public ICollection<Dish>? Dishes { get; set; }

    // Method to update the IsOpen status
    public void UpdateIsOpenStatus()
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        IsOpen = OpeningHour <= currentTime && ClosingHour >= currentTime;
    }
}
