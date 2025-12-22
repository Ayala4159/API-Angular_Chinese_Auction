using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Models
{
    public class Package
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int NumOfCards { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
