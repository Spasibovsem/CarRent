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

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IGenericRepository<Payment> _repository;

        public PaymentController(IGenericRepository<Payment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<Payment> GetPaymentsByCar(int id)
        {
            return _repository.FindAll().Where(p => p.CarId == id);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddPayment([FromQuery] Payment model)
        {
            _repository.Insert(model);
            _repository.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeletePayment(int id)
        {
            _repository.DeleteById(id);
            _repository.Save();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdatePayment(int id, [FromQuery] Payment model)
        {
            Payment obj = _repository.FindById(id);
            if (obj != null)
            {
                obj.CarId = model.CarId;
                obj.DriverId = model.DriverId;
                obj.PayDate = model.PayDate;
                obj.PaySum = model.PaySum;
                _repository.Update(obj);
                _repository.Save();
            }
            else return BadRequest();

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
                CarId = id,
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
