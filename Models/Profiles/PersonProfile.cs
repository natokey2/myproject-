using System;
using AutoMapper;
using ReceptWebApi.Models.Domain;
using ReceptWebApi.Models.DTO;

namespace ReceptWebApi.Models.Profiles
{
	public class PersonProfile:Profile
	{
		public PersonProfile()
		{

			//En mappningsklass som används för att mappa person med
			//Med personResponseDto
			
            CreateMap<Person, PersonResponseDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
	}
}

