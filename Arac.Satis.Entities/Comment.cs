using Arac.Satis.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Entities
{
    public class Comment : EntityBase , IEntity
    {
        public string Content { get; set; }
        public int VehicleId { get; set; }
        public int? UserId { get; set; }
        public Vehicle Vehicle { get; set; }
        public User User { get; set; }

    }
}
