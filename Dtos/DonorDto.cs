using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class CreateDonorDto
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
        [MaxLength(30)]
        public string? Company_name { get; set; }
        public string? Company_description { get; set; }
        public string? Company_picture { get; set; }
        [Required]
        public bool Is_publish { get; set; } = false;
    }
    public class UserGetDonorDto
    {
        public string? Company_name { get; set; }
        public string? Company_description { get; set; }
        public string? Company_picture { get; set; }
        [Required]
        public bool Is_publish { get; set; }
    }
}
