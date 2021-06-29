using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRent.Services;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _service;

        public RepairController(IRepairService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<RepairModel> GetRepairsByCarId(int id)
        {
            return _service.RepairsByCarId(id);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddRepair([FromQuery] RepairModel model)
        {
            if (ModelState.IsValid)
                _service.InsertRepair(model);
            else
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateRepair([FromQuery] RepairModel model, int id)
        {
            if (ModelState.IsValid)
                _service.UpdRepair(model, id);
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            _service.DelRepair(id);
            return Ok();
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public RepairSumModel GetRepairSumByCar(int id)
        {
            return _service.RepairSumByCar(id);
        }
    }
}

