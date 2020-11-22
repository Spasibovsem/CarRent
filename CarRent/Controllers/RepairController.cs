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
    public class RepairController : ControllerBase
    {
        private readonly IGenericRepository<Repair> _repository;

        public RepairController(IGenericRepository<Repair> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<Repair> GetRepairsByCarId(int id)
        {
            return _repository.FindAll().Where(r => r.CarId == id);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddRepair([FromQuery]Repair model)
        {
            _repository.Insert(model);
            _repository.Save();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateRepair(int id, [FromQuery] Repair model)
        {
            var obj = _repository.FindById(id);
            if (obj != null)
            {
                obj.Title = model.Title;
                obj.CarId = model.CarId;
                obj.Mileage = model.Mileage;
                obj.RepairDate = model.RepairDate;
                obj.RepairPrice = model.RepairPrice;
                _repository.Update(obj);
                _repository.Save();
            }
            else return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            _repository.DeleteById(id);
            _repository.Save();
            return Ok();
        }
    }
}

