using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;

namespace CarRent.Services
{
    public interface IRepairService
    {
        IEnumerable<RepairModel> RepairsByCarId(int id);
        void InsertRepair(RepairModel model);
        void DelRepair(int id);
        void UpdRepair(RepairModel model, int id);
        RepairSumModel RepairSumByCar(int id);
    }
}
