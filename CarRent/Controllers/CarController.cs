using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Data.Repo;
using CarRent.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IGenericRepository<Car> _repository;
        private readonly IMapper _mapper;
        public CarController(IGenericRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<CarModel> GetCars()
        {
            return _mapper.Map<List<CarModel>>(_repository.FindAll());
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddCar([FromQuery] CarModel model)
        {
            if (ModelState.IsValid)
                _repository.Insert(_mapper.Map<Car>(model));
            else
                return BadRequest();
            return Ok();
        }
        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            _repository.DeleteById(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdateCar([FromQuery]CarModel model)
        {
            if (ModelState.IsValid)
            {
                var car = _repository.FindById(model.Id);
                car.Name = model.Name;
                car.Mileage = model.Mileage;
                car.PurchasePrice = model.PurchasePrice;
                car.PurchaseDate = model.PurchaseDate;
                _repository.Update(car);
            }
            else return BadRequest();
            return Ok();
        }
    }
}
