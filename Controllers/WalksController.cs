using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.Domain;
using Walks.API.Models.DTO;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequest)
        {
            try
            {
                var walkDomainModel = mapper.Map<Walk>(addWalkRequest);
                await walkRepository.CreateAsync(walkDomainModel);
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework like Serilog or NLog)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomainModel = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkReqDto updateWalkReqDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkReqDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
