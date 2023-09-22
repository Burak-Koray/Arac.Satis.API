using Arac.Satis.Data.Repositories;
using Arac.Satis.Entities;
using Arac.Satis.Model.VehicleDtos;
using Arac.Satis.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Service
{
    public class VehicleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleManager()
        {
            _unitOfWork = new UnitOfWork();
        }
        public VehicleDto Get(int vehicleId)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.Get(a => a.Id == vehicleId && !a.IsDeleted);

            VehicleDto vehicleDto = vehicle.ToDto();

            vehicleDto.User = _unitOfWork.UserRepository.Get(u => u.Id == vehicle.UserId).ToDto();
            vehicleDto.Category = _unitOfWork.CategoryRepository.Get(c => c.Id == vehicle.CategoryId).ToDto();
            vehicleDto.Comments = _unitOfWork.CommentRepository.GetAll(c => c.VehicleId == vehicle.Id).ToDto().ToList();

            return vehicleDto;
        }

        public List<VehicleDto> GetAll()
        {

            List<VehicleDto> vehicleDtos = (from a in _unitOfWork.VehicleRepository.GetAll()
                                            join c in _unitOfWork.CategoryRepository.GetAll() on a.CategoryId equals c.Id
                                            join u in _unitOfWork.UserRepository.GetAll() on a.UserId equals u.Id
                                            select new VehicleDto
                                            {
                                                Id = a.Id,
                                                Content = a.Content,
                                                IsDeleted = a.IsDeleted,
                                                Title = a.Title,
                                                State = a.IsDeleted ? "Silindi" : "Aktif",
                                                CreatedDate = a.CreatedDate,
                                                Category = c.ToDto(),
                                                User = u.ToDto(),
                                                FileName = a.FileName
                                            }).ToList();
            return vehicleDtos;

        }

        public List<VehicleDto> GetAll(int categoryId)
        {
            List<VehicleDto> vehicleDtos = GetAll();
            vehicleDtos = vehicleDtos.Where(a => a.Category.Id == categoryId && !a.IsDeleted).ToList();
            return vehicleDtos;
        }

        public List<VehicleDto> GetAllNonDeleted()
        {
            List<VehicleDto> vehicleDtos = GetAll();
            vehicleDtos = vehicleDtos.Where(a => !a.IsDeleted).ToList();
            return vehicleDtos;
        }

        public void Add(AddVehicleDto addVehicleDto)
        {
            try
            {
                _unitOfWork.VehicleRepository.Add(addVehicleDto.ToEntity());
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(UpdateVehicleDto updateVehicleDto, int vehicleId)
        {
            try
            {
                Vehicle vehicle = _unitOfWork.VehicleRepository.Get(a => a.Id == vehicleId);

                vehicle.Title = updateVehicleDto.Title;
                vehicle.Content = updateVehicleDto.Content;
                vehicle.CategoryId = updateVehicleDto.CategoryId;
                vehicle.ModifedDate = DateTime.Now;
                vehicle.ModifedBy = "Burak Koray";

                _unitOfWork.VehicleRepository.Update(vehicle);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int vehicleId)
        {
            try
            {
                Vehicle vehicle = _unitOfWork.VehicleRepository.Get(a => a.Id == vehicleId);
                vehicle.IsDeleted = true;
                vehicle.DeletedDate = DateTime.Now;
                vehicle.DeletedBy = "Burak Koray";
                _unitOfWork.VehicleRepository.Update(vehicle);
                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SetActive(int vehicleId)
        {
            try
            {
                Vehicle vehicle = _unitOfWork.VehicleRepository.Get(a => a.Id == vehicleId);
                vehicle.IsDeleted = false;
                vehicle.ModifedBy = "Burak Koray";
                vehicle.ModifedDate = DateTime.Now;

                _unitOfWork.VehicleRepository.Update(vehicle);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
