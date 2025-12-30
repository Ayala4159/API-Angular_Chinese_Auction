using ChineseAuction.Dtos;
using ChineseAuction.Models;

namespace ChineseAuction.Service
{
    public interface IDonorService
    {
        Task<ManagerGetDonorDto> AddDonorAsync(CreateDonorDto donor);
        Task<bool> DeleteDonorAsync(int id);
        Task<IEnumerable<Donor>> GetAllDonorsAsync();
        Task<Donor?> GetDonorByIdAsync(int id);
        Task<Donor?> UpdateDonorAsync(int id, CreateDonorDto donor);
    }
}