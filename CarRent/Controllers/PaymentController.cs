using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using CarRent.Services;
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
    public class PaymentController : ControllerBase
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public PaymentController(CarRentContext context, IMapper mapper, IPaymentService paymentService)
        {
            _context = context;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IEnumerable<PaymentModel> GetPaymentsByCar(int id)
        {
            return _mapper.Map<List<PaymentModel>>(_context.Payments.Where(p => p.CarId == id));

        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddPayment([FromQuery] PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Payments.Add(_mapper.Map<Payment>(model));
                _context.SaveChanges();
            }
            else
                return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult DeletePayment(int id)
        {
            var obj = _context.Payments.Find(id);
            _context.Payments.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("[Action]/{id}")]
        public IActionResult UpdatePayment(int id, [FromQuery]PaymentModel model)
        { 
            if(ModelState.IsValid)
            {
                var obj = _context.Payments.Find(id);
                obj.CarId = model.CarId;
                obj.DriverId = model.DriverId;
                obj.PayDate = model.PayDate;
                obj.PaySum = model.PaySum;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else 
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByCar(int id)
        {
            return _paymentService.SumByCar(id);
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public PaySumModel GetPaySumByDriver(int id)
        {
            return _paymentService.SumByDriver(id);
        }

        [HttpGet]
        [Route("[Action]/{driverId}/{carId}")]
        public PaySumModel GetPaySumByDriverCar(int driverId, int carId)
        {
            return _paymentService.SumByDriverCar(driverId, carId);
        }
    }
}
