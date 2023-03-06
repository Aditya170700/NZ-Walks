using System;
using AutoMapper;

namespace NZ_Walks.Profiles
{
	public class WalkProfile : Profile
	{
		public WalkProfile()
		{
			CreateMap<Models.Domain.Walk, Models.Dto.Walk.Walk>()
				.ReverseMap();
			CreateMap<Models.Domain.WalkDifficulty, Models.Dto.Walk.WalkDifficulty>()
				.ReverseMap();
            CreateMap<Models.Domain.Walk, Models.Dto.Walk.AddWalkRequest>()
                .ReverseMap();
            CreateMap<Models.Domain.Walk, Models.Dto.Walk.UpdateWalkRequest>()
                .ReverseMap();
        }
	}
}

