using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;

namespace CarRent.Services
{
    public interface IRepairService
    {
        RepairSumModel RepairSumByCar(int id);
    }
}
