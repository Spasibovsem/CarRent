using System;
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

        public PaymentService(CarRentContext context)
        {
            _context = context;
        }
        public PaySumModel SumByCar(int id)
        {
            return new PaySumModel
            {
                CarName = _context.Cars.Find(id).Name,
                DriverName = null,
                PaymentSum = _context.Payments
                    .Where(p => p.CarId == id)
                    .Sum(p => p.PaySum)
            };
        }
        public PaySumModel SumByDriver(int id)
        {
            return new PaySumModel
            {
                DriverName = _context.Drivers.Find(id).Name,
                CarName = null,
                PaymentSum = _context.Payments
                   .Where(p => p.DriverId == id)
                   .Sum(p => p.PaySum)
            };
        }
        public PaySumModel SumByDriverCar(int driverId, int carId)
        {
            return new PaySumModel
            {
                CarName = _context.Cars.Find(carId).Name,
                DriverName = _context.Drivers.Find(driverId).Name,
                PaymentSum = _context.Payments
                    .Where(p => p.CarId == carId && p.DriverId == driverId)
                    .Sum(p => p.PaySum)
            };
        }
    }
}
