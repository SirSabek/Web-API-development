using AutoMapper;
using HotelListing.data;
using HotelListing.Models;

namespace HotelListing.Configurations;

public class MapperInitilizer : Profile
{
    public MapperInitilizer()
    {
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, CreateCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, CreateCountryDto>().ReverseMap();
    }
}