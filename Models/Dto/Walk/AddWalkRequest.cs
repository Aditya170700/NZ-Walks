using System;
namespace NZ_Walks.Models.Dto.Walk
{
	public class AddWalkRequest
	{
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}

