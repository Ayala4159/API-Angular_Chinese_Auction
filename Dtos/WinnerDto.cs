using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Dtos
{
    public class WinnerDto
    {
        public int WinnerID { get; set; }
        [Required, ForeignKey("WinnerID")]
        public User winner { get; set; }
        [Required]
        public int GiftId { get; set; }
        [Required, ForeignKey("GiftId")]
        public Gift Gift { get; set; }
    }
}
