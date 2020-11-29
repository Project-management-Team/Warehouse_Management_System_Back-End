using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IItemService _itemService;

        public WarehouseController(IWarehouseService warehouseService, IItemService itemService)
        {
            _warehouseService = warehouseService;
            _itemService = itemService;
        }

        [HttpPost]
        public async Task CreateWarehouse([FromBody] WarehouseModel model)
        {
            await _warehouseService.CreateWareHouse(new Warehouse
            {
                Name = model.Name,
                Address = model.Address
            });
        }

        [HttpGet("items")]
        public async Task<Items[]> GetWarehouseItems([FromQuery] int whId)
        {
            return await _itemService.GetWarehouseItems(whId);
        }
    }
}
