using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using CarRent.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _PaymentService;

        public PaymentController(IPaymentService payService)
        {
            _PaymentService = payService;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<PaymentModel> GetPaymentsByCar(int id)
        {
            return _PaymentService.PaymentsByCar(id);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddPayment([FromQuery] PaymentModel model)
        {
            if (ModelState.IsValid)
                _PaymentService.InsertPayment(model);
            else
                return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeletePayment(int id)
        {
            _PaymentService.DelPayment(id);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdatePayment([FromQuery] PaymentModel model)
        { 
            if(ModelState.IsValid)
                _PaymentService.UpdPayment(model);
            else 
                return BadRequest();

            return Ok();
        }
        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByCar(int id)
        {
            return _PaymentService.SumByCar(id);
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByDriver(int id)
        {
            return _PaymentService.SumByDriver(id);
        }

        [HttpGet]
        [Route("[Action]/{driverId}/{carId}")]
        public PaySumModel GetPaySumByDriverCar(int driverId, int carId)
        {
            return _PaymentService.SumByDriverCar(driverId, carId);
        }
    }
}
