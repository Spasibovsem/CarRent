using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repo;
using AutoMapper;
using Data.Models;
using CarRent.Models;

namespace CarRent.Services
{
    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<Driver> _repository;
        private readonly IMapper _mapper;
        public DriverService(IGenericRepository<Driver> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void UpdDriver(DriverModel model)
        {
            var obj = _repository.FindById(model.Id);
            obj.Name = model.Name;
            obj.StartDate = model.StartDate;
            obj.RetireDate = model.RetireDate;
            obj.CarId = model.CarId;
            _repository.Update(obj);
        }
        public void DelDriver(int id)
        {
            _repository.DeleteById(id);
        }
        public void InsertDriver(DriverModel model)
        {
            _repository.Insert(_mapper.Map<Driver>(model));
        }
        public IEnumerable<DriverModel> GetAllDrivers()
        {
            return _mapper.Map<List<DriverModel>>(_repository.FindAll());
        }
    }
}
