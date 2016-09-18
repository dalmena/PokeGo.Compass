using System;

namespace PokeGo.Compass.Api.Exceptions
{
    public class BusinessException : Exception 
    {
        public BusinessCodeEnum Code { get; }

        public BusinessException(BusinessCodeEnum code)
        {
            Code = code;
        }
    }
}
