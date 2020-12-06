using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;


namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpPost]
        public async Task CreateTruck([FromBody] TruckModel model)
        {
            await _truckService.CreateTruck(new Trucks
            {
                Height = model.Height,
                Width = model.Width,
                Number = model.Number
            });
        }

        [HttpDelete]
        public async Task DeleteTruck([FromQuery] int truckId)
        {
            await _truckService.DeleteTruck(truckId);
        }

        [HttpGet]
        public async Task<Trucks> GetTruck([FromQuery] int truckId)
        {
            return await _truckService.GetTruck(truckId);
        }

        [HttpGet("cells")]
        public async Task<TruckCells[]> GetTruckCells([FromQuery] int truckId)
        {
            return await _truckService.GetTruckCells(truckId);
        }

        [HttpPost("fill-cell")]
        public async Task PutItemToCell([FromQuery] int cellId, [FromQuery] int itemId)
        {
            await _truckService.PutItemToCell(cellId, itemId);
        }

        [HttpGet("all")]
        public async Task<Trucks[]> GetAllTrucks()
        {
            return await _truckService.GetAllTrucks();
        }
    }
}
