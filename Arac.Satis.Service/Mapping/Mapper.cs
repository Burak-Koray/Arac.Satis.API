using Arac.Satis.Entities;
using Arac.Satis.Model.VehicleDtos;
using Arac.Satis.Model.CategoryDtos;
using Arac.Satis.Model.CommentDtos;
using Arac.Satis.Model.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Service.Mapping
{
    public static class Mapper
    {
        #region VehicleDtos
        public static VehicleDto ToDto(this Vehicle vehicle)
        {
            return new VehicleDto
            {
                Id = vehicle.Id,
                Title = vehicle.Title,
                Content = vehicle.Content,
                IsDeleted = vehicle.IsDeleted,
                FileName = vehicle.FileName
            };
        }
        public static IEnumerable<VehicleDto> ToDto(this IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(a => ToDto(a));
        }
        public static Vehicle ToEntity(this AddVehicleDto addVehicleDto)
        {
            return new Vehicle
            {

                Title = addVehicleDto.Title,
                Content = addVehicleDto.Content,
                CategoryId = addVehicleDto.CategoryId,
                IsDeleted = false,
                UserId = 1,
                CreatedDate = DateTime.Now,
                FileName = addVehicleDto.FileName
            };
        }
        #endregion

        #region UserDtos
        public static UserDto ToDto(this User user)
        {
            if (user != null)
            {
                return new UserDto { Id = user.Id, Name = user.Name, Surname = user.Surname, Username = user.Username };
            }
            else
            {
                return null;
            }


        }
        #endregion

        #region CategoryDto
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                State = category.IsDeleted ? "Silindi" : "Aktif"
            };
        }
        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> categories)
        {
            return categories.Select(c => c.ToDto());
        }
        public static Category ToEntity(this AddCategoryDto addCategoryDto)
        {
            return new Category { Name = addCategoryDto.Name, Description = addCategoryDto.Description, CreatedDate = DateTime.Now, IsDeleted = false };
        }
        #endregion

        #region CommentDtos
        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto { Id = comment.Id, Content = comment.Content, User = comment.User.ToDto() };
        }
        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comments)
        {
            return comments.Select(x => x.ToDto());
        }
        public static Comment ToEntity(this AddCommentDto addCommentDto)
        {
            return new Comment { Content = addCommentDto.Content, CreatedDate = DateTime.Now, UserId = 1, IsDeleted = false, VehicleId = addCommentDto.VehicleId };
        }
        #endregion

    }
}
