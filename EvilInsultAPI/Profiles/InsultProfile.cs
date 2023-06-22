using EvilInsultAPI.Models.Domain;
using AutoMapper;
using EvilInsultAPI.Models.DTOs.InsultDTOs;

namespace EvilInsultAPI.Profiles
{
    public class InsultProfile : Profile
    {
        public InsultProfile() 
        {
            CreateMap<InsultGeneralDTO, Insult>();
            CreateMap<InsultPostDTO, Insult>();
        }
    }
}
