using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Models
{
    public class Basket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GiftId { get; set; }
        [Required, ForeignKey("GiftId")]
        public Gift Gift { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required, ForeignKey("PackageId")]
        public Package? Package { get; set; }
        [Required]
        public int CardsQuantity { get; set; }
        [Required]
        public string UniquePackageId { get; set; }
    }
}
