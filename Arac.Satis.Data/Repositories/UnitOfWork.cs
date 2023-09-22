using Arac.Satis.Data.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly DataContext _dataContext;

        public UnitOfWork()
        {
            _dataContext = new DataContext();
        }

        private readonly VehicleRepository _vehicleRepository;
        private readonly CategoryRepository _categoryRepository;    
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;    

        public IVehicleRepository VehicleRepository => _vehicleRepository ?? new VehicleRepository(_dataContext);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_dataContext);

        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_dataContext);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext.SaveChanges(); 
        }
    }
}
