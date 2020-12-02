using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Car, CarModel>();
            CreateMap<CarModel, Car>();
            CreateMap<Driver, DriverModel>();
            CreateMap<DriverModel, Driver>();
            CreateMap<Repair, RepairModel>();
            CreateMap<RepairModel, Repair>();
            CreateMap<Payment, PaymentModel>();
            CreateMap<PaymentModel, Payment>();
        }
    }
}
