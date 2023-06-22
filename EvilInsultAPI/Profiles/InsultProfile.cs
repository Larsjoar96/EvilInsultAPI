using EvilInsultAPI.Models.Domain;
using AutoMapper;
using EvilInsultAPI.Models.DTOs.InsultDTOs;

namespace EvilInsultAPI.Profiles
{
    public class InsultProfile : Profile
    {
        public InsultProfile() 
        {
            CreateMap<Insult, InsultGeneralDTO>();
            CreateMap<Insult, InsultPostDTO>();
        }
    }
}
