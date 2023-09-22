using Arac.Satis.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Entities
{
    public class Category : EntityBase , IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
