using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.Models.Domain;
using NZ_Walks.Models.Dto;
using NZ_Walks.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZ_Walks.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _regionRepository.GetAllAsync();

            return Ok(_mapper.Map<List<Models.Dto.Region>>(result));
        }

        [HttpGet("{Id}")]
        [ActionName("GetByIdAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _regionRepository.GetByIdAsync(Id);

            if (result == null)
            {
                throw new Exception($"Region with id {Id} doesnt exists");
            }

            return Ok(_mapper.Map<Models.Dto.Region>(result));
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddAsync(Models.Dto.AddRegionRequest addRegionRequest)
        {
            var result = await _regionRepository.AddAsync(_mapper.Map<Models.Domain.Region>(addRegionRequest));

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = result.Id }, _mapper.Map<Models.Dto.Region>(result));
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateAsync(Guid Id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var region = await _regionRepository.GetByIdAsync(Id);

            if (region == null)
            {
                throw new Exception($"Region with id {Id} doesnt exists");
            }

            var result = await _regionRepository.UpdateAsync(region, _mapper.Map<Models.Domain.Region>(updateRegionRequest));

            return Ok(_mapper.Map<Models.Dto.Region>(result));
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteByIdAsync(Guid Id)
        {
            var region = await _regionRepository.GetByIdAsync(Id);

            if (region == null) {
                throw new Exception($"Region with id {Id} doesnt exists");
            }

            await _regionRepository.DeleteAsync(region);

            return Ok(_mapper.Map<Models.Dto.Region>(region));
        }
    }
}

