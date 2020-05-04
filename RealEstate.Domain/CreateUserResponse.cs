

using RealEstate.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain
{
   public sealed  class CreateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
