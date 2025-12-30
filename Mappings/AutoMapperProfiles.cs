using AutoMapper;
using ChineseAuction.Dtos;
using ChineseAuction.Models;


namespace Chinese_Auction.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Category
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();

            // Gift
            CreateMap<Gift, GetGiftDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
            CreateMap<CreateGiftDto, Gift>();
            CreateMap<UserUpdateGiftDto, Gift>()
                .ForMember(dest => dest.Purchases_quantity, opt => opt.Condition((src, dest, srcMember) => srcMember != 0));

            // Package
            CreateMap<Package, GetPackageDto>();
            CreateMap<CreatePackageDto, Package>();

            // Purchase
            CreateMap<CreatePurchaseDto, Purchase>();
            CreateMap<Purchase, GetPurchaseDto>();
            CreateMap<UpdatePurchaseDto, Purchase>();

            // Basket
            CreateMap<CreateBasketDto, Basket>();
            CreateMap<Basket, GetBasketDto>();

            // Donor
            CreateMap<CreateDonorDto, Donor>();
            CreateMap<Donor, ManagerGetDonorDto>();
            CreateMap<Donor, UserGetDonorDto>();

            // User
            CreateMap<CreateUserDto, User>();
            CreateMap<User, GetUserDto>();

        }
    }
}