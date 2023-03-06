using System;
using AutoMapper;

namespace NZ_Walks.Profiles
{
	public class WalkDifficultyProfile : Profile
	{
		public WalkDifficultyProfile()
		{
			CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty.WalkDifficulty>()
				.ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty.AddWalkDifficultyRequest>()
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty.UpdateWalkDifficultyRequest>()
                .ReverseMap();
        }
	}
}

