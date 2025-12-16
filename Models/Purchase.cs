using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Models
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GiftId { get; set; }
        [Required, ForeignKey("GiftId")]
        public Gift Gift { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, ForeignKey("UseId]")]
        public User User { get; set; }
        [Required]
        public DateTime Pruchases_date { get; } = DateTime.Now;

    }
}
