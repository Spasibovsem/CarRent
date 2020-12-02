using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;
using Data.Repo;
using Data.Models;
using AutoMapper;

namespace CarRent.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _repository;
        private readonly IMapper _mapper;
        public PaymentService(IGenericRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void InsertPayment(PaymentModel model)
        {
            _repository.Insert(_mapper.Map<Payment>(model));
        }
        public void DelPayment(int id)
        {
            _repository.DeleteById(id);
        }
        public void UpdPayment(PaymentModel model)
        {
            var obj = _repository.FindById(model.Id);
            obj.CarId = model.CarId;
            obj.DriverId = model.DriverId;
            obj.PayDate = model.PayDate;
            obj.PaySum = model.PaySum;
            _repository.Update(obj);
        }
        public IEnumerable<PaymentModel> PaymentsByCar(int id)
        {
            return _mapper.Map<List<PaymentModel>>(_repository.FindAll().Where(p => p.CarId == id));
        }
        public PaySumModel SumByCar(int id)
        {
            return new PaySumModel
            {
                CarId = id,
                DriverId = null,
                PaymentSum = _repository.FindAll()
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
                PaymentSum = _repository.FindAll()
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
                PaymentSum = _repository.FindAll()
                    .Where(p => p.CarId == carId && p.DriverId == driverId)
                    .Sum(p => p.PaySum)
            };
        }
    }
}
