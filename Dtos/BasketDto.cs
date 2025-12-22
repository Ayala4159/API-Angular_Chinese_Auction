using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Dtos
{
    public class CreateBasketDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GiftId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CardsQuantity { get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required]
        public string UniquePackageId { get; set; }
    }
    public class GetBasketDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GiftId { get; set; }
        [Required]
        public int CardsQuantity { get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required]
        public string UniquePackageId { get; set; }
    }

}
