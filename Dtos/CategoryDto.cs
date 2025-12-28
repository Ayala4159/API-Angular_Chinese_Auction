using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }=string.Empty;
    }
    public class GetCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public ICollection<GiftDto> Gifts { get; set; } = new List<GiftDto>();
    }
}
