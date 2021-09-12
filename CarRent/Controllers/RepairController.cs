using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;

        public RepairController(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult GetRepairsByCarId(int id)
        {
            return Ok(_mapper.Map<List<RepairModel>>(_context.Repairs.Where(r => r.CarId == id)));
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddRepair([FromQuery] RepairModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Repair>(model));
                _context.SaveChanges();
            }
            else
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdateRepair([FromQuery] RepairModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.Repairs.Find(id);
                obj.Title = model.Title;
                obj.CarId = model.CarId;
                obj.Mileage = model.Mileage;
                obj.RepairDate = model.RepairDate;
                obj.RepairPrice = model.RepairPrice;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            var obj = _context.Repairs.Find(id);
            _context.Repairs.Remove(obj);
            _context.SaveChanges();

            return Ok();
        }

        //[HttpGet]
        //[Route("[Action]/{id}")]
        //public RepairSumModel GetRepairSumByCar(int id)
        //{
        //    return _service.RepairSumByCar(id);
        //}
    }
}

