using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repo;
using CarRent.Models;
using AutoMapper;

namespace CarRent.Services
{
    public class CarService
    {
        private readonly IGenericRepository<Car> _repository;
        private readonly IMapper _mapper;
        public CarService(IGenericRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void UpdCar(CarModel model)
        {
            var obj = _repository.FindById(model.Id);
            obj.Name = model.Name;
            obj.Mileage = model.Mileage;
            obj.PurchaseDate = model.PurchaseDate;
            obj.PurchasePrice = model.PurchasePrice;
            _repository.Update(obj);
        }
        public void DelCar(int id)
        {
            _repository.DeleteById(id);
        }
        public void InsertCar(CarModel model)
        {
            _repository.Insert(_mapper.Map<Car>(model));
        }
        public IEnumerable<CarModel> GetAllCars()
        {
            return _mapper.Map<List<CarModel>>(_repository.FindAll());
        }
    }
}
