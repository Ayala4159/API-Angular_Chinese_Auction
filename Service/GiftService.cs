using AutoMapper;
using ChineseAuction.Dtos;
using ChineseAuction.Models;
using ChineseAuction.Repositoreis;

namespace ChineseAuction.Service
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IMapper _mapper;
        public GiftService(IGiftRepository giftRepository, IMapper mapper)
        {
            _giftRepository = giftRepository;
            _mapper = mapper;
        }

        //get all approved gifts
        public async Task<IEnumerable<GetGiftDto>> GetAllApprovedGiftsAsync()
        {
            var gifts = await _giftRepository.GetAllApprovedGiftsAsync();
            return _mapper.Map<IEnumerable<GetGiftDto>>(gifts);
        }

        //get all none approved gifts
        public async Task<IEnumerable<GetGiftDto>> GetAllUnapprovedGiftsAsync()
        {
            var gifts = await _giftRepository.GetAllUnapprovedGiftsAsync();
            return _mapper.Map<IEnumerable<GetGiftDto>>(gifts);
        }

        //get gift by id
        public async Task<GetGiftDto?> GetGiftByIdAsync(int id)
        {
            var gift = await _giftRepository.GetGiftByIdAsync(id);
            return gift == null ? null : _mapper.Map<GetGiftDto>(gift);
        }

        //add gift
        public async Task<GetGiftDto> AddGiftAsync(CreateGiftDto giftDto)
        {
            var gift = _mapper.Map<Gift>(giftDto);
            var addedGift = await _giftRepository.AddGiftAsync(gift);
            return _mapper.Map<GetGiftDto>(addedGift);
        }

        //update gift
        public async Task<GetGiftDto?> UpdateGiftAsync(int id, CreateGiftDto giftDto)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(id);
            if (existingGift == null) return null;
            var gift = _mapper.Map<Gift>(giftDto);
            existingGift.Id = id;
            var updatedGift = await _giftRepository.UpdateGiftAsync(existingGift);
            return updatedGift == null ? null : _mapper.Map<GetGiftDto>(updatedGift);
        }

        //update gift purchases quantity
        public async Task<UserUpdateGiftDto?> UpdateGiftPurchasesQuantityAsync(int giftId)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(giftId);
            if (existingGift == null) return null;
            var updatedGift = await _giftRepository.UpdateGiftPurchasesQuantityAsync(giftId);
            return updatedGift == null ? null : _mapper.Map<UserUpdateGiftDto>(updatedGift);
        }

        //delete gift
        public async Task<bool> DeleteGiftAsync(int id)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(id);
            if (existingGift == null) return false;
            await _giftRepository.DeleteGiftAsync(id);
            return true;
        }

    }
}
