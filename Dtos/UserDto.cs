using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class CreateUserDto
    {
        [Required, EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required, MinLength(8), MaxLength(20)]
        public string Password { get; set; }
        [Required, MaxLength(30)]
        public string First_name { get; set; }
        [Required, MaxLength(30)]
        public string Last_name { get; set; }
        public string? Phone { get; set; }
    }

    public class UserLoginDto
    {
        [Required, EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required, MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
    public class GetUserDto
    {
        public string Email { get; set; }
        [Required, MaxLength(30)]
        public string First_name { get; set; }
        [Required, MaxLength(30)]
        public string Last_name { get; set; }
        public string? Phone { get; set; }
        [Required]
        public Role Role { get; set; } = Role.customer;
        public ICollection<Basket> Basket { get; set; } = new List<Basket>();
        public ICollection<Purchase> Purchase { get; set; } = new List<Purchase>();

    }
}
