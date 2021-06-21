using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using CarRent.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Services
{
    public class DriverService : IDriverService
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;
        public DriverService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void UpdDriver(DriverModel model)
        {
            var obj = _context.Drivers.Find(model.Id);
            obj.Name = model.Name;
            obj.StartDate = model.StartDate;
            obj.RetireDate = model.RetireDate;
            obj.CarId = model.CarId;
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DelDriver(int id)
        {
            var obj = _context.Drivers.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
        public void InsertDriver(DriverModel model)
        {
            _context.Drivers.Add(_mapper.Map<Driver>(model));
            _context.SaveChanges();
        }
        public IEnumerable<DriverModel> GetAllDrivers()
        {
            return _mapper.Map<List<DriverModel>>(_context.Drivers);
        }
    }
}
