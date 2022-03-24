using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginDto>();
        }
    }
}