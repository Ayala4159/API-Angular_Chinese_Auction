using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Dtos
{
    public class GiftDto
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }=string.Empty;
        [Required, MaxLength(100)]
        public string Description { get; set; }=string.Empty;
        public string? Details { get; set; }
        public string Picture { get; set; }=string.Empty;
        [Required]
        public int DonorId { get; set; }
        [Required]
        public string CategoryName { get; set; }=string.Empty;
        [Required]
        public bool Is_lottery { get; set; }
    }
    public class UserUpdateGiftDto {
        [Required]
        public int Purchases_quantity { get; set; }
    }
}
