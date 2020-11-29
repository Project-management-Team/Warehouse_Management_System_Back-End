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
    public class WHLockerController : ControllerBase
    {
        private readonly IWHLockerService _lockerService;

        public WHLockerController(IWHLockerService lockerService)
        {
            _lockerService = lockerService;
        }

        [HttpPost]
        public async Task CreateLocker([FromBody] LockerModel model)
        {
            await _lockerService.CreateLocker(new Whlockers
            {
                Column = model.Column,
                Height = model.Height,
                Name = model.Name,
                Row = model.Row,
                WhzoneId = model.WhzoneId,
                Width = model.Width
            });
        }

        [HttpGet]
        public async Task<Whlockers> GetLockerById([FromQuery] int lockerId)
        {
            return await _lockerService.GetLockerById(lockerId);
        }

        [HttpGet("zone-lockers")]
        public async Task<Whlockers[]> GetWhZones([FromQuery] int zoneId)
        {
            return await _lockerService.GetZoneLockers(zoneId);
        }
    }
}
