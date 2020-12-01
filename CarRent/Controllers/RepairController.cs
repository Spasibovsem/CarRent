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
using CarRent.Models;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IGenericRepository<Repair> _repository;
        private readonly IMapper _mapper;

        public RepairController(IGenericRepository<Repair> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<RepairModel> GetRepairsByCarId(int id)
        {
            return _mapper.Map<List<RepairModel>>(_repository.FindAll().Where(r => r.CarId == id));
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddRepair([FromQuery] RepairModel model)
        {
            _repository.Insert(_mapper.Map<Repair>(model));
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdateRepair([FromQuery] RepairModel model)
        {
            if(ModelState.IsValid)
            {
                var obj = _repository.FindById(model.Id);
                obj.Title = model.Title;
                obj.CarId = model.CarId;
                obj.Mileage = model.Mileage;
                obj.RepairDate = model.RepairDate;
                obj.RepairPrice = model.RepairPrice;
                _repository.Update(obj);
            }
            else return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            _repository.DeleteById(id);
            return Ok();
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public RepairSumModel GetRepairSumByCar(int id)
        {
            return new RepairSumModel
            {
                CarId = id,
                RepairSum = _repository.FindAll().Where(r => r.CarId == id).Sum(r => r.RepairPrice)
            };
        }
    }
}

