using ChineseAuction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Required, ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required, ForeignKey("PackageId")]
        public Package? Package { get; set; }
        [Required]
        public DateTime Pruchase_date { get; set; } = DateTime.Now;
        [Required]
        public string UniquePackageId { get; set; }
    }
}
//[HttpPost("confirm-purchase")]
//public async Task<IActionResult> ConfirmPurchase(List<BasketItemDTO> itemsFromClient)
//{
//    foreach (var bundle in itemsFromClient) // רץ על כל "חבילה" שהלקוח קנה
//    {
//        // כאן הקסם קורה! 
//        // אנחנו מייצרים מזהה אחד וייחודי עבור כל החבילה הזו
//        string uniquePackageGroupId = Guid.NewGuid().ToString();

//        // עכשיו ניצור שורה בטבלת Purchase עבור כל כרטיס בתוך החבילה הזו
//        foreach (var giftId in bundle.GiftIds)
//        {
//            var p = new Purchase
//            {
//                GiftId = giftId,
//                PackageId = bundle.PackageId,
//                GroupIdentifier = uniquePackageGroupId, // כולם מקבלים את אותו הקוד המשותף!
//                UserId = currentUserId,
//                Pruchase_date = DateTime.Now
//            };
//            _context.Purchase.Add(p);
//        }
//    }
//    await _context.SaveChangesAsync();
//    return Ok();
//}