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
    public class WHCellController : ControllerBase
    {
        private readonly IWHCellService _cellService;

        public WHCellController(IWHCellService CellService)
        {
            _cellService = CellService;
        }

        [HttpPost]
        public async Task CreateCell([FromBody] CellModel model)
        {
            await _cellService.CreateCell(new Whcells
            {
                Column = model.Column,
                ItemId = model.ItemId,
                Name = model.Name,
                Row = model.Row,
                WhlockerId = model.WhlockerId,
                Status = model.Status
            });
        }

        [HttpGet]
        public async Task<Whcells> GetCellById([FromQuery] int cellId)
        {
            return await _cellService.GetCellById(cellId);
        }

        [HttpGet("item")]
        public async Task<Items> GetWhZones([FromQuery] int cellId)
        {
            return await _cellService.GetCellItem(cellId);
        }
    }
}
