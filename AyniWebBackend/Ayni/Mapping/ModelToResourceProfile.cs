using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Resources;

namespace AyniWebBackend.Ayni.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
  
    }
}