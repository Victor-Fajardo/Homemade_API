using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Succes { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        protected BaseResponse(T resource)
        {
            Succes = true;
            Message = string.Empty;
            Resource = resource;
        }
        protected BaseResponse(string message)
        {
            Succes = false;
            Message = message;
        }
    }
}
