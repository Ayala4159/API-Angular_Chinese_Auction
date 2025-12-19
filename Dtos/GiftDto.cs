using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Dtos
{
    public class GiftDto
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public string? Details { get; set; }
        public string Picture { get; set; }
        [Required]
        public int DonorName { get; set; }
        [Required]
        public int CategoryName { get; set; }
        public int Card_price { get; set; }
    }
    public class UserUpdateGiftDto {
        [Required]
        public int Purchases_quantity { get; set; }
    }
    public class lotorryGiftDto
    {
        [Required]
        public int Purchases_quantity { get; set; }
    }
}
