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
    public class RepairService : IRepairService
    {
        private readonly CarRentContext _context;
        private readonly IMapper _mapper;

        public RepairService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<RepairModel> RepairsByCarId(int id)
        {
            return _mapper.Map<List<RepairModel>>(_context.Repairs.Where(r => r.CarId == id));
        }
        public void InsertRepair(RepairModel model)
        {
            _context.Add(_mapper.Map<Repair>(model));
            _context.SaveChanges();
        }
        public void DelRepair(int id)
        {
            var obj = _context.Repairs.Find(id);
            _context.Repairs.Remove(obj);
            _context.SaveChanges();
        }
        public void UpdRepair(RepairModel model)
        {
            var obj = _context.Repairs.Find(model.Id);
            obj.Title = model.Title;
            obj.CarId = model.CarId;
            obj.Mileage = model.Mileage;
            obj.RepairDate = model.RepairDate;
            obj.RepairPrice = model.RepairPrice;
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public RepairSumModel RepairSumByCar(int id)
        {
            return new RepairSumModel
            {
                CarId = id,
                RepairSum = _context.Repairs.Where(r => r.CarId == id).Sum(r => r.RepairPrice)
            };
        }
    }
}
