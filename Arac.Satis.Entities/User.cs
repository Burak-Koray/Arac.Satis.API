using Arac.Satis.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Entities
{
    public class User : EntityBase , IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
