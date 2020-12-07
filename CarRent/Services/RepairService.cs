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
    public class RepairService : IRepairService
    {
        private readonly IGenericRepository<Repair> _repository;
        private readonly IMapper _mapper;

        public RepairService(IGenericRepository<Repair> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<RepairModel> RepairsByCarId(int id)
        {
            return _mapper.Map<List<RepairModel>>(_repository.FindAll().Where(r => r.CarId == id));
        }
        public void InsertRepair(RepairModel model)
        {
            _repository.Insert(_mapper.Map<Repair>(model));
        }
        public void DelRepair(int id)
        {
            _repository.DeleteById(id);
        }
        public void UpdRepair(RepairModel model)
        {
            var obj = _repository.FindById(model.Id);
            obj.Title = model.Title;
            obj.CarId = model.CarId;
            obj.Mileage = model.Mileage;
            obj.RepairDate = model.RepairDate;
            obj.RepairPrice = model.RepairPrice;
            _repository.Update(obj);
        }
        public RepairSumModel RepairSumByCar(int id)
        {
            return new RepairSumModel
            {
                CarId = id,
                RepairSum = _repository.FindAll().Where(r => r.CarId == id).Sum(r => r.RepairPrice)
            };
        }
    }
}
