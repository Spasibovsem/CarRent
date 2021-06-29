using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;

namespace CarRent.Services
{
    public interface ICarService
    {
        void UpdCar(CarModel model, int id);
        void DelCar(int id);
        void InsertCar(CarModel model);
        IEnumerable<CarModel> GetAllCars();
    }
}
