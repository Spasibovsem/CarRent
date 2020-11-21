using System;
using Data;
using Data.Models;
using Data.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IGenericRepository<Driver> _repository;

        public DriverController(IGenericRepository<Driver> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<Driver> GetDrivers()
        {
            return _repository.FindAll();
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddDriver(Driver model)
        {
            _repository.Insert(model);
            _repository.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            _repository.DeleteById(id);
            _repository.Save();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateDriver(int id, [FromQuery] Driver model)
        {
            Driver obj = _repository.FindById(id);
            if (obj != null)
            {
                obj.Name = model.Name;
                obj.StartDate = model.StartDate;
                obj.RetireDate = model.RetireDate
                    ;
                obj.CarId = model.CarId;
                _repository.Update(obj);
                _repository.Save();
            }
            else return BadRequest();

            return Ok();
        }
    }
}
