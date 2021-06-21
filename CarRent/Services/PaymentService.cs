﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;
using Data.Models;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;
        public PaymentService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void InsertPayment(PaymentModel model)
        {
            _context.Payments.Add(_mapper.Map<Payment>(model));
            _context.SaveChanges();
        }
        public void DelPayment(int id)
        {
            var obj = _context.Payments.Find(id);
            _context.Payments.Remove(obj);
            _context.SaveChanges();
        }
        public void UpdPayment(PaymentModel model)
        {
            var obj = _context.Payments.Find(model.Id);
            obj.CarId = model.CarId;
            obj.DriverId = model.DriverId;
            obj.PayDate = model.PayDate;
            obj.PaySum = model.PaySum;
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<PaymentModel> PaymentsByCar(int id)
        {
            return _mapper.Map<List<PaymentModel>>(_context.Payments.Where(p => p.CarId == id));
        }
        public PaySumModel SumByCar(int id)
        {
            return new PaySumModel
            {
                CarId = id,
                DriverId = null,
                PaymentSum = _context.Payments
                    .Where(p => p.CarId == id)
                    .Sum(p => p.PaySum)
            };
        }
        public PaySumModel SumByDriver(int id)
        {
            return new PaySumModel
            {
                DriverId = id,
                CarId = null,
                PaymentSum = _context.Payments
                   .Where(p => p.DriverId == id)
                   .Sum(p => p.PaySum)
            };
        }
        public PaySumModel SumByDriverCar(int driverId, int carId)
        {
            return new PaySumModel
            {
                CarId = carId,
                DriverId = driverId,
                PaymentSum = _context.Payments
                    .Where(p => p.CarId == carId && p.DriverId == driverId)
                    .Sum(p => p.PaySum)
            };
        }
    }
}
