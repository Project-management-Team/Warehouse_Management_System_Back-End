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

        [HttpPost("book")]
        public async Task BookLocker([FromQuery] int lockerId)
        {
            await _lockerService.BookLocker(lockerId);
        }

        [HttpPost("free")]
        public async Task FreeLocker([FromQuery] int lockerId)
        {
            await _lockerService.FreeLocker(lockerId);
        }

        [HttpGet]
        public async Task<LockerInfo> GetLockerById([FromQuery] int lockerId)
        {
            return await _lockerService.GetLockerById(lockerId);
        }

        [HttpGet("zone-lockers")]
        public async Task<Whlockers[]> GetZoneLockers([FromQuery] int zoneId)
        {
            return await _lockerService.GetZoneLockers(zoneId);
        }

        [HttpDelete]
        public async Task RemoveLocker([FromQuery] int lockerId)
        {
            await _lockerService.RemoveLocker(lockerId);
        }
    }
}
