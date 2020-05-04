
using RealEstate.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain
{
   public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<Error> Errors { get; }
        protected BaseGatewayResponse(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
