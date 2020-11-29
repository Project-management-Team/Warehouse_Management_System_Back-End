using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;

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
        public async Task<Whzones> GetZoneById([FromQuery] int zoneId)
        {
            return await _zoneService.GetZoneById(zoneId);
        }

        [HttpGet("wh-zones")]
        public async Task<Whzones[]> GetWhZones([FromQuery] int whId)
        {
            return await _zoneService.GetWhZones(whId);
        }
    }
}
