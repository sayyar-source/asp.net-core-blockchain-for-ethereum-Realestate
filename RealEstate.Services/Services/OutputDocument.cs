using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Services.Services
{
    [FunctionOutput]
    public class OutputDocument
    {
        [Parameter("bool", "Result", 1)]
        public bool Result { get; set; }
    }
}
