using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRent.Models;
using CarRent.Services;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;

        public DriverController(IDriverService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<DriverModel> GetDrivers()
        {
            return _service.GetAllDrivers();
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddDriver([FromQuery]DriverModel model)
        {
            if (ModelState.IsValid)
                _service.InsertDriver(model);
            else
                return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            _service.DelDriver(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdateDriver([FromQuery] DriverModel model)
        {
            if (ModelState.IsValid)
                _service.UpdDriver(model);
            else
                return BadRequest();

            return Ok();
        }
    }
}
