using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Models.DTO;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();
 
            // Map domain models to Dto's
            var regionDto = mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            return Ok(
                mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegionRequestDto regionRequestDto)
        {
            // map DTO to Data Model
            var regionDomainModel= mapper.Map<Region>(regionRequestDto);

            regionDomainModel = await regionRepository.createAsync(regionDomainModel);

            // mapp Domain Model to Dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] RegionRequestDto regionRequestDto)
        {
            // Map the DTO to the domain model
            var regionDomainModel = mapper.Map<Region>(regionRequestDto);

            regionDomainModel = await regionRepository.updateAsync(id, regionDomainModel);
            
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            await dbContext.SaveChangesAsync();

            // Map the updated domain model to a DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(region));
        }
    }
}
