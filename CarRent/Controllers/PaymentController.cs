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
    public class PaymentController : ControllerBase
    {
        private readonly IGenericRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public PaymentController(IGenericRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<PaymentModel> GetPaymentsByCar(int id)
        {
            return _mapper.Map<List<PaymentModel>>(_repository.FindAll().Where(p => p.CarId == id));
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddPayment([FromQuery] PaymentModel model)
        {
            _repository.Insert(_mapper.Map<Payment>(model));
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeletePayment(int id)
        {
            _repository.DeleteById(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdatePayment([FromQuery] PaymentModel model)
        { 
            if(ModelState.IsValid)
            { 
                var obj = _repository.FindById(model.Id);        
                obj.CarId = model.CarId;
                obj.DriverId = model.DriverId;
                obj.PayDate = model.PayDate;
                obj.PaySum = model.PaySum;
                _repository.Update(obj);
            }
            else 
                return BadRequest();

            return Ok();
        }
        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByCar(int id)
        {
            return new PaySumModel
            {
                CarId = id,
                DriverId = null,
                PaymentSum = _repository.FindAll().Where(p => p.CarId == id).Sum(p => p.PaySum)
            };
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByDriver(int id)
        {
            return new PaySumModel
            {
                DriverId = id,
                CarId = null,
                PaymentSum = _repository.FindAll().Where(p => p.DriverId == id).Sum(p => p.PaySum)
            };
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByDriverCar(int _carId, int _driverId)
        {
            return new PaySumModel
            {
                CarId = _carId,
                DriverId = _driverId,
                PaymentSum = _repository.FindAll().Where(p => p.CarId == _carId && p.DriverId == _driverId).Sum(p => p.PaySum)
            };
        }
    }
}
