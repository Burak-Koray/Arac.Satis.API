using Arac.Satis.API.Controllers.Base;
using Arac.Satis.Model.CommentDtos;
using Arac.Satis.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arac.Satis.API.Controllers
{
    
    public class CommentController : BaseController
    {

        [HttpGet]
        [Route("GetListNonDeletedByVehicleId")]
        public List<CommentDto> GetListNonDeletedByVehicleId(int vehicleId)
        {
            CommentManager commentManager = new();
            return commentManager.GetListNonDeletedByVehicleId(vehicleId);
        }

        [HttpGet]
        [Route("GetListByVehicleId")]
        public List<CommentDto> GetListByVehicleId(int vehicleId)
        {
            CommentManager commentManager = new();
            return commentManager.GetListByVehicleId(vehicleId);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AddCommentDto addCommentDto)
        {
            CommentManager commentManager = new();
            commentManager.Add(addCommentDto);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int commentId)
        {
            CommentManager commentManager = new();
            commentManager.Delete(commentId);
        }
    }
}
