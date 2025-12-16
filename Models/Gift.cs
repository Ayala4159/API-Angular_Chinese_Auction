using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuction.Models
{
    public class Gift
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public string Details { get; set; }
        public string Picture { get; set; }
        [Required]
        public int DonorId { get; set; }
        [Required, ForeignKey("DonorId")]
        public Donor Donor { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int Purchases_quantity { get; set; }
        public int Card_price { get; set; }
        public User? Winner { get; set; } = null;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
