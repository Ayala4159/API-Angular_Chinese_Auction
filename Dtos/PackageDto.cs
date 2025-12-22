using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class PackageDto
    {
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
