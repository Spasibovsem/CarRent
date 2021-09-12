using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models;

namespace CarRent.Services
{
    public interface IPaymentService
    {

        PaySumModel SumByCar(int id);
        PaySumModel SumByDriver(int id);
        PaySumModel SumByDriverCar(int driverId, int carId);
        
    }
}
