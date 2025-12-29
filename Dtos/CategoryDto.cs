using ChineseAuction.Models;
using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }=string.Empty;
    }
    public class GetCategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public ICollection<GiftDto> Gifts { get; set; } = new List<GiftDto>();
    }
}
