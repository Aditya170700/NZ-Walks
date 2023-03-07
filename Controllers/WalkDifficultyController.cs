using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.Models.Dto.WalkDifficulty;
using NZ_Walks.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZ_Walks.Controllers
{
    [ApiController]
    [Route("api/walk-difficultys")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _walkDifficultyRepository.GetAllAsync();

            return Ok(_mapper.Map<List<Models.Dto.WalkDifficulty.WalkDifficulty>>(result));
        }

        [HttpGet("{Id}")]
        [ActionName("GetByIdAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _walkDifficultyRepository.GetByIdAsync(Id);

            if (result == null) {
                throw new Exception($"Walk difficulty with id {Id} doesnt exists");
            }

            return Ok(_mapper.Map<Models.Dto.WalkDifficulty.WalkDifficulty>(result));
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddAsync([FromBody] AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var result = await _walkDifficultyRepository.AddAsync(_mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequest));

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = result.Id }, _mapper.Map<Models.Dto.WalkDifficulty.WalkDifficulty>(result));
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateAsync(Guid Id, [FromBody] UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var walkDifficulty = await _walkDifficultyRepository.GetByIdAsync(Id);

            if (walkDifficulty == null)
            {
                throw new Exception($"Walk difficulty difficulty with id {Id} doesnt exists");
            }

            var result = await _walkDifficultyRepository.UpdateAsync(walkDifficulty, _mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequest));

            return Ok(_mapper.Map<Models.Dto.WalkDifficulty.WalkDifficulty>(walkDifficulty));
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var walkDifficulty = await _walkDifficultyRepository.GetByIdAsync(Id);

            if (walkDifficulty == null)
            {
                throw new Exception($"Walk difficulty difficulty with id {Id} doesnt exists");
            }

            await _walkDifficultyRepository.DeleteAsync(walkDifficulty);

            return Ok(_mapper.Map<Models.Dto.WalkDifficulty.WalkDifficulty>(walkDifficulty));
        }
    }
}

