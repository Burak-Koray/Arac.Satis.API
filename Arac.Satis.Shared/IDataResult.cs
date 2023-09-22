using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Shared
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
