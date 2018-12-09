using DotnetCore.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
   public class BaseAddress
    {
        public string Address { get; set; }
        public string Locality { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int AddressType { get; set; } = Constants.ADDRESSTYPEWORK;
    }
}
