using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Data.Repositories
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }
        IUserRepository UserRepository { get; } 
        ICommentRepository CommentRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void SaveChanges();


    }
}
