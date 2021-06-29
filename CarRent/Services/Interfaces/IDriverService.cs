using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;

namespace CarRent.Services
{
    public interface IDriverService
    {
        void UpdDriver(DriverModel model, int id);
        void DelDriver(int id);
        void InsertDriver(DriverModel model);
        IEnumerable<DriverModel> GetAllDrivers();
    }
}
