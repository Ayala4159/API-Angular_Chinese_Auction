using AutoMapper;
using ChineseAuction.Dtos;
using ChineseAuction.Models;
using ChineseAuction.Repositoreis;

namespace ChineseAuction.Service
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;
        public PackageService(IPackageRepository repository, IMapper mapper)
        {
            this._packageRepository = repository;
            this._mapper = mapper;
        }
        // Methods for CRUD operations on Package entity

        // get all packages
        public async Task<IEnumerable<GetPackageDto>> GetAllPackagesAsync()
        {
            var packages = await _packageRepository.GetAllPackagesAsync();
            return _mapper.Map<IEnumerable<GetPackageDto>>(packages);
        }

        // get package by id
        public async Task<GetPackageDto?> GetPackageByIdAsync(int id)
        {
            var package = await _packageRepository.GetPackageByIdAsync(id);
            if (package == null) return null;
            return _mapper.Map<GetPackageDto>(package);
        }

        // add new package
        public async Task<GetPackageDto> AddPackageAsync(CreatePackageDto createPackageDto)
        {
            var package = _mapper.Map<Package>(createPackageDto);
            await _packageRepository.AddPackageAsync(package);
            return _mapper.Map<GetPackageDto>(package);
        }

        // update package
        public async Task<GetPackageDto?> UpdatePackageAsync(int id, CreatePackageDto updatePackageDto)
        {
            var existingPackage = await _packageRepository.GetPackageByIdAsync(id);
            if (existingPackage == null) return null;
            _mapper.Map(updatePackageDto, existingPackage);
            existingPackage.Id = id;
            var updatedPackage = await _packageRepository.UpdatePackageAsync(existingPackage);
            return updatedPackage == null ? null : _mapper.Map<GetPackageDto>(updatedPackage);
        }

        // delete package
        public async Task<bool> DeletePackageAsync(int id)
        {
            var existingPackage = await _packageRepository.GetPackageByIdAsync(id);
            if (existingPackage == null) return false;
            await _packageRepository.DeletePackageAsync(id);
            return true;
        }
    }
}
