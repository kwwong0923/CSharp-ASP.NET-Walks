using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }


        // POST - Create Walk
        // url: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Mapping: DTO -> Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            // Action Method - Create
            await walkRepository.CreateAsync(walkDomainModel);

            // Mapping: Domain -> DTO
            //WalkDto walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
