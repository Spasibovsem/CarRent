using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Data.Repo;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IGenericRepository<Car> _repository;

        public CarController(IGenericRepository<Car> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<Car> GetCars()
        {
            return _repository.FindAll();
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddCar([FromQuery] Car model)
        {
            _repository.Insert(model);
            _repository.Save();
            return Ok(model);
        }
        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            _repository.DeleteById(id);
            _repository.Save();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateCar(int id,[FromQuery] Car model)
        {
            Car car = _repository.FindById(id);
            if (car != null)
            {
                car.Name = model.Name;
                car.Mileage = model.Mileage;
                car.PurchasePrice = model.PurchasePrice;
                car.PurchaseDate = model.PurchaseDate;
                _repository.Update(car);
                _repository.Save();
            }
            else
                return BadRequest();
            return Ok();
        }
    }
}
