using ChineseAuction.Models;

namespace ChineseAuction.Repositoreis
{
    public interface IGiftRepository
    {
        Task<Gift> AddGiftAsync(Gift gift);
        Task DeleteGiftAsync(int id);
        Task<IEnumerable<Gift>> GetAllApprovedGiftsAsync();
        Task<IEnumerable<Gift>> GetAllUnapprovedGiftsAsync();
        Task<Gift?> GetGiftByIdAsync(int id);
        Task<IEnumerable<Gift>> GetGiftsByCategoryAsync(int categoryId);
        Task<IEnumerable<Gift>> GetGiftsByDonorAsync(int donorId);
        Task<Gift?> UpdateGiftAsync(Gift gift);
        Task<Gift?> UpdateGiftPurchasesQuantityAsync(int giftId);
        Task<bool> UpdateApprovalStatusAsync(int giftId, bool v);

    }
}