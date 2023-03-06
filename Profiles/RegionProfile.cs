using System;
using AutoMapper;

namespace NZ_Walks.Profiles
{
	public class RegionProfile : Profile
	{
		public RegionProfile()
		{
			CreateMap<Models.Domain.Region, Models.Dto.Region>()
				.ReverseMap();
            CreateMap<Models.Dto.AddRegionRequest, Models.Domain.Region>()
                .ReverseMap();
            CreateMap<Models.Dto.UpdateRegionRequest, Models.Domain.Region>()
                .ReverseMap();
        }
	}
}

