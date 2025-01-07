using System.ComponentModel.DataAnnotations;

namespace DoorDashAPI.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(25)]
        public string? UserName { get; set; }

        [Required, StringLength(20)]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? ProfilePicture {  get; set; }
    }
}
