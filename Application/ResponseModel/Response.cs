using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseModel
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; } = true;

        public T Result { get; set; }

        public object Errors { get; set; }
    }
}
