using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;
using WarehouseManagementSystem.Shared.PublicModels;

namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WHZoneController : ControllerBase
    {
        private readonly IWHZoneService _zoneService;

        public WHZoneController(IWHZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        [HttpPost]
        public async Task CreateZone([FromBody] ZoneModel model)
        {
            await _zoneService.CreateZone(new Whzones
            {
                Column = model.Column,
                Height = model.Height,
                Name = model.Name,
                Row = model.Row,
                Whid = model.Whid,
                Width = model.Width
            });
        }

        [HttpGet]
        public async Task<ZoneInfo> GetZoneById([FromQuery] int zoneId)
        {
            return await _zoneService.GetZoneById(zoneId);
        }

        [HttpPost("book")]
        public async Task BookZone([FromQuery] int zoneId, [FromQuery] int amount)
        {
            await _zoneService.BookZone(zoneId, amount);
        }

        [HttpPost("free")]
        public async Task FreeZone([FromQuery] int zoneId)
        {
            await _zoneService.FreeZone(zoneId);
        }

        [HttpGet("wh-zones")]
        public async Task<Whzones[]> GetWhZones([FromQuery] int whId)
        {
            return await _zoneService.GetWhZones(whId);
        }

        [HttpDelete]
        public async Task RemoveZone([FromQuery] int zoneId)
        {
            await _zoneService.RemoveZone(zoneId);
        }
    }
}
