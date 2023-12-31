﻿using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsService _UnitsService;

        public UnitsController(StoragesDbContext context)
        {
            _UnitsService = new UnitsService(context);
        }
        [HttpGet("get")]
        public List<Unit> Get()
        {
            var units = _UnitsService.GetListUnits();
            return units;
        }
        [HttpPost("create")]
        public IActionResult Create(Unit unit)
        {
            var newUnit = _UnitsService.CreateUnit(unit);
            if (newUnit != null)
            {
                return Ok(newUnit);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(Unit unit)
        {
            Unit updated = _UnitsService.UpdateUnit(unit);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool updated = _UnitsService.DeleteUnit(id);
            return Ok(updated);
        }
    }
}
