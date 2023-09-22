using Arac.Satis.Data.Repositories;
using Arac.Satis.Entities;
using Arac.Satis.Model.CommentDtos;
using Arac.Satis.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Service
{
    public class CommentManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager()
        {
            _unitOfWork = new UnitOfWork();
        }
        private IEnumerable<CommentDto> GetAllQuery(int vehicleId)
        {
            return (from c in _unitOfWork.CommentRepository.GetAll(c => c.VehicleId == vehicleId)
                    join u in _unitOfWork.UserRepository.GetAll() on c.UserId equals u.Id
                    select new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                        CreatedDate = c.CreatedDate,
                        IsDeleted = c.IsDeleted,
                        User = u.ToDto()
                    }).AsEnumerable<CommentDto>();
        }


        public List<CommentDto> GetListNonDeletedByVehicleId(int vehicleId)
        {
            var commentDtos = GetAllQuery(vehicleId).Where(c => !c.IsDeleted).ToList();
            return commentDtos;
        }

        public List<CommentDto> GetListByVehicleId(int vehicleId)
        {
            var commentDtos = GetAllQuery(vehicleId).ToList();
            return commentDtos;
        }

        public void Add(AddCommentDto addCommentDto)
        {
            try
            {
                _unitOfWork.CommentRepository.Add(addCommentDto.ToEntity());
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int commentId)
        {
            try
            {
                Comment comment = _unitOfWork.CommentRepository.Get(c => c.Id == commentId);
                comment.IsDeleted = true;
                comment.DeletedBy = "Burak Koray";
                comment.DeletedDate = DateTime.Now;
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
