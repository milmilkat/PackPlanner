using Microsoft.AspNetCore.Mvc;
using PackPlanner.Models.Dtos;
using PackPlanner.Services.Interfaces;

namespace PackPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> ListItemsAsync()
        {
            var result = await _itemService.ListItemsAsync();
            return result.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemByIdAsync([FromRoute] int id)
        {
            return await _itemService.GetItemByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddItemAsync([FromBody] Item item)
        {
            return await _itemService.AddItemAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync([FromRoute] int id, [FromBody] Item item)
        {
            await _itemService.UpdateItemAsync(id, item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync([FromRoute] int id)
        {
            await _itemService.DeleteItemAsync(id);
            return Ok();
        }
    }
}