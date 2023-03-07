using System;
using AutoMapper;

namespace NZ_Walks.Profiles
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			CreateMap<Models.Domain.User, Models.Dto.Auth.RegisterRequest>()
				.ReverseMap();
            CreateMap<Models.Domain.User, Models.Dto.Auth.RegisterResponse>()
                .ReverseMap();
        }
	}
}

