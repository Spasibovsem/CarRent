using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using CarRent.Models;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly CarRentContext _context;
        public CarService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void UpdCar(CarModel model)
        { 
            var obj = _context.Cars.Find(model.Id);
            obj.Name = model.Name;
            obj.Mileage = model.Mileage;
            obj.PurchaseDate = model.PurchaseDate;
            obj.PurchasePrice = model.PurchasePrice;
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DelCar(int id)
        {
            var obj = _context.Cars.Find(id);
            _context.Cars.Remove(obj);
            _context.SaveChanges();
        }
        public void InsertCar(CarModel model)
        {
            _context.Cars.Add(_mapper.Map<Car>(model));
            _context.SaveChanges();
        }
        public IEnumerable<CarModel> GetAllCars()
        {
            return _mapper.Map<List<CarModel>>(_context.Cars);
        }
    }
}
