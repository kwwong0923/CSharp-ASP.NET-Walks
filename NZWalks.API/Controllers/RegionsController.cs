using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Controllers;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) 
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        // Action Methods

        // GET ALL REGIONS
        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            // Get data from database - Domain Models
            var regions = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOS
            //var regionDto = new List<RegionDto>();
            //foreach (var region in regions)
            //{
            //    regionDto.Add(new RegionDto()
            //    { 
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}

            // Auto Mapper - Map Domin Models to DTOs
            var regionDto = mapper.Map<List<RegionDto>>(regions);

            // Return DTOS
            return Ok(regionDto);
        }

        // GET: Get Region by ID
        // api/regions/{id}
        // optinoal: :Guid -> Type saftey
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById ([FromRoute] Guid id)
        {
            // Find -> Primary Key
            // var region = dbContext.Regions.Find(id);
            // Find one element
            var region = await regionRepository.GetByIdAsync(id);
            
            if (region == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto()
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImageUrl = region.RegionImageUrl,
            //};

            // Auto Mapper - Model -> DTO
            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        // POST: Create New Region
        // api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to Domain Model
            Region regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            //Region regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            //};

            // Use Domain Model to create Region
            // After Add(), the object got the Guid
            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model back to DTO
            //RegionDto regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            RegionDto regionDto = mapper.Map<RegionDto>(regionDomainModel);
            // 201 - Created    
            // CreatedAtAction(name of action, route value, value)
            // The header contains location which is the url of Get By Id Action
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }

        // Update
        // /api/regions/{id}
        [HttpPut]
        [Route("{id:GUid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto ) 
        {
            Region regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            // MAP DTO to Domain Model
            //Region regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
            //};

            // Check the region
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map DTO to Domain Model
            //regionDomainModel.Code = updateRegionRequestDto.Code;
            //regionDomainModel.Name = updateRegionRequestDto.Name;
            //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            //if (updateRegionRequestDto.Name != null) regionDomainModel.Name = updateRegionRequestDto.Name;
            //if (updateRegionRequestDto.Code != null) regionDomainModel.Code = updateRegionRequestDto.Code;
            //if (updateRegionRequestDto.RegionImageUrl != null) regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            // Convert Domain Model to DTO
            RegionDto regionDto = mapper.Map<RegionDto>(regionDomainModel);
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return Ok(regionDto); 
        }

        // PATCH
        [HttpPatch]
        [Route("{id:Guid}")]
        public async Task<IActionResult> PatchUpdate([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model
            Region regionDomainModel = new Region()
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
            };

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //if (updateRegionRequestDto.Name != null) regionDomainModel.Name = updateRegionRequestDto.Name;
            //if (updateRegionRequestDto.Code != null) regionDomainModel.Code = updateRegionRequestDto.Code;
            //if (updateRegionRequestDto.RegionImageUrl != null) regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            RegionDto regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        // DELETE
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //// Delete Region
            //// There is not Remove Async
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            // (Optional: return deleted object)
            RegionDto regionDto = mapper.Map<RegionDto>(regionDomainModel);
            //RegionDto regionDto = new RegionDto()
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return Ok($"The region - {regionDto.Name} is deleted");
        }
    }
}
