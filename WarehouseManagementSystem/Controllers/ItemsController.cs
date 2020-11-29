using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task CreateItem([FromBody] ItemModel model)
        {
            await _itemService.CreateItem(new Items
            {
                SerialNumber = model.SerialNumber,
                Description = model.Description
            });
        }

        [HttpDelete]
        public async Task DeleteItem([FromQuery] int itemId)
        {
            await _itemService.RemoveItem(itemId);
        }

        [HttpPatch]
        public async Task MoveItem([FromQuery] int itemId, [FromQuery] int currentCellId, [FromQuery] int destinationCellId)
        {
            await _itemService.MoveItem(itemId, currentCellId, destinationCellId);
        }
    }
}
