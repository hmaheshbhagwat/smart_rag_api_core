using AutoMapper;
using smart_rag_api_core.Models.Data;
using smart_rag_api_core.Models.DTO;

namespace smart_rag_api_core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
