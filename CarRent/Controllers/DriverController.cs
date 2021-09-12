using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRent.Models;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;

        public DriverController(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetDrivers()
        {
            return Ok(_mapper.Map<List<DriverModel>>(_context.Drivers));
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddDriver([FromQuery]DriverModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Drivers.Add(_mapper.Map<Driver>(model));
                _context.SaveChanges();
            }
            else
                return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var obj = _context.Drivers.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateDriver([FromQuery]DriverModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.Drivers.Find(id);
                obj.Name = model.Name;
                obj.StartDate = model.StartDate;
                obj.RetireDate = model.RetireDate;
                obj.CarId = model.CarId;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
                return BadRequest();

            return Ok();
        }
    }
}
