using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.Models.Domain;
using NZ_Walks.Models.Dto;
using NZ_Walks.Models.Dto.Walk;
using NZ_Walks.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZ_Walks.Controllers
{
    [ApiController]
    [Route("api/walks")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<List<Models.Dto.Walk.Walk>>(result));
        }

        [HttpGet("{Id}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _walkRepository.GetByIdAsync(Id);

            if (result == null)
            {
                throw new Exception($"Walk with id {Id} doesnt exists");
            }

            return Ok(_mapper.Map<Models.Dto.Walk.Walk>(result));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]Models.Dto.Walk.AddWalkRequest addWalkRequest)
        {
            var result = await _walkRepository.AddAsync(_mapper.Map<Models.Domain.Walk>(addWalkRequest));

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = result.Id }, _mapper.Map<Models.Dto.Walk.Walk>(result));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync(Guid Id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            var walk = await _walkRepository.GetByIdAsync(Id);

            if (walk == null)
            {
                throw new Exception($"Walk with id {Id} doesnt exists");
            }
            
            var result = await _walkRepository.UpdateAsync(walk, _mapper.Map<Models.Domain.Walk>(updateWalkRequest));

            return Ok(_mapper.Map<Models.Dto.Walk.Walk>(result));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid Id)
        {
            var walk = await _walkRepository.GetByIdAsync(Id);

            if (walk == null)
            {
                throw new Exception($"Walk with id {Id} doesnt exists");
            }

            await _walkRepository.DeleteByIdAsync(walk);

            return Ok(_mapper.Map<Models.Dto.Walk.Walk>(walk));
        }
    }
}

