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
        public RepairService(CarRentContext context)
        {
            _context = context;
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
