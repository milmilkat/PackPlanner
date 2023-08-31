using Microsoft.AspNetCore.Mvc;
using PackPlanner.Models.Dtos;
using PackPlanner.Services.Interfaces;

namespace PackPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IPackService _packService;

        public PackController(ILogger<ItemController> logger, IPackService packService)
        {
            _logger = logger;
            _packService = packService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pack>>> ListPacksAsync([FromQuery] ListPackRequest listPackRequest)
        {
            var result = await _packService.ListPacksAsync(listPackRequest);
            return result.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pack>> GetPackByIdAsync([FromRoute] int id)
        {
            return await _packService.GetPackByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPackAsync([FromBody] Pack pack)
        {
            return await _packService.AddPackAsync(pack);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePackAsync([FromRoute] int id, [FromBody] Pack pack)
        {
            await _packService.UpdatePackAsync(id, pack);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePackAsync([FromRoute] int id)
        {
            await _packService.DeletePackAsync(id);
            return Ok();
        }
    }
}