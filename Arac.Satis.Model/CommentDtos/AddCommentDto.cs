using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Model.CommentDtos
{
    public class AddCommentDto
    {
        public string Content { get; set; }
        public int VehicleId { get; set; }
    }
}
