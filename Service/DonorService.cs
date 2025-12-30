using AutoMapper;
using ChineseAuction.Dtos;
using ChineseAuction.Models;
using ChineseAuction.Repositoreis;

namespace ChineseAuction.Service
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRpository _donorRepository;
        private readonly IMapper _mapper;
        public DonorService(IDonorRpository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        // Service methods for handling business logic related to Donor entity

        // get all donors
        public async Task<IEnumerable<Models.Donor>> GetAllDonorsAsync()
        {
            var donors = await _donorRepository.GetAllDonorsAsync();
            return _mapper.Map<IEnumerable<Donor>>(donors);
        }
        // get donor by id
        public async Task<Donor?> GetDonorByIdAsync(int id)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(id);
            if (donor == null) return null;
            return _mapper.Map<Donor>(donor);
        }

        // add new donor
        public async Task<ManagerGetDonorDto> AddDonorAsync(CreateDonorDto donor)
        {
            if (await DonorEmailExistsAsync(donor.Email, -1))
            {
                throw new Exception("Email already exists");
            }
            var existingDonor = _mapper.Map<Donor>(donor);
            await _donorRepository.AddDonorAsync(existingDonor);
            return _mapper.Map<ManagerGetDonorDto>(existingDonor);
        }

        // update donor
        public async Task<Donor?> UpdateDonorAsync(int id, CreateDonorDto donor)
        {
            if (await DonorEmailExistsAsync(donor.Email, id))
            {
                throw new Exception("Email already exists");
            }
            var existingDonor = await _donorRepository.GetDonorByIdAsync(id);
            if (existingDonor == null) return null;
            _mapper.Map(donor, existingDonor);
            existingDonor.Id = id;
            var updatedDonor = await _donorRepository.UpdateDonorAsync(existingDonor);
            return updatedDonor == null ? null : _mapper.Map<Donor>(updatedDonor);
        }
        // delete donor
        public async Task<bool> DeleteDonorAsync(int id)
        {
            var existingDonor = await _donorRepository.GetDonorByIdAsync(id);
            if (existingDonor == null) return false;
            await _donorRepository.DeleteDonorAsync(id);
            return true;
        }
        // Check if donor mail exists
        private async Task<bool> DonorEmailExistsAsync(string email, int v)
        {
            return await _donorRepository.DonorEmailExistsAsync(email, v);
        }
    }
}
