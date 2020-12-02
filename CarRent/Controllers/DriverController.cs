using System;
using Data;
using Data.Models;
using Data.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarRent.Models;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IGenericRepository<Driver> _repository;
        private readonly IMapper _mapper;

        public DriverController(IGenericRepository<Driver> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Action]")]
        public IEnumerable<DriverModel> GetDrivers()
        {
            return _mapper.Map<List<DriverModel>>(_repository.FindAll());
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddDriver([FromQuery]DriverModel model)
        {
            if (ModelState.IsValid)
                _repository.Insert(_mapper.Map<Driver>(model));
            else
                return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            _repository.DeleteById(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateDriver([FromQuery] Driver model)
        {
            if (ModelState.IsValid)
            {
                var obj = _repository.FindById(model.Id);
                obj.Name = model.Name;
                obj.StartDate = model.StartDate;
                obj.RetireDate = model.RetireDate;
                obj.CarId = model.CarId;
                _repository.Update(obj);
            }
            else 
                return BadRequest();

            return Ok();
        }
    }
}
