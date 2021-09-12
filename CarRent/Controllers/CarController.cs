using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CarRentContext _context;
        public CarController(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetCars()
        {
            return Ok(_mapper.Map<List<CarModel>>(_context.Cars));
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddCar([FromQuery] CarModel model)
        {
            if (ModelState.IsValid)
            { 
                _context.Cars.Add(_mapper.Map<Car>(model)); 
                _context.SaveChanges();
            }
            else
                return BadRequest();
            return Ok();
        }
        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var obj = _context.Cars.Find(id);
            _context.Cars.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateCar([FromQuery]CarModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.Cars.Find(id);
                obj.Name = model.Name;
                obj.Mileage = model.Mileage;
                obj.PurchaseDate = model.PurchaseDate;
                obj.PurchasePrice = model.PurchasePrice;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
                return BadRequest();
            return Ok();
        }
    }
}
