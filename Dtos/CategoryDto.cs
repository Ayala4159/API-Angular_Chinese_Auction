using System.ComponentModel.DataAnnotations;

namespace ChineseAuction.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
