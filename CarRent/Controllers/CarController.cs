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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService service)
        {
            _carService = service;
        }
        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<CarModel> GetCars()
        {
            return _carService.GetAllCars();
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddCar([FromQuery] CarModel model)
        {
            if (ModelState.IsValid)
                _carService.InsertCar(model);
            else
                return BadRequest();
            return Ok();
        }
        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            _carService.DelCar(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdateCar([FromQuery]CarModel model)
        {
            if (ModelState.IsValid)
            {
                _carService.UpdCar(model);
            }
            else return BadRequest();
            return Ok();
        }
    }
}
