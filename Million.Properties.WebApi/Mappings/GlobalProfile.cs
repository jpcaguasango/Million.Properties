using AutoMapper;
using Million.Properties.Domain.Entities;
using Million.Properties.WebApi.Dtos;

namespace Million.Properties.WebApi.Mappings;

public class GlobalProfile: Profile
{
    public GlobalProfile()
    {
        CreateMap<Property, PropertyDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<PropertyImage, PropertyImageDto>();
        CreateMap<PropertyTrace, PropertyTraceDto>();
    }
}