using DotnetCore.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
   public abstract class BaseEntity
    {
        public bool IsActive { get; set; } = CommonFunction.GetStatusTrue;
        public DateTime CreatedDate { get; set; } = CommonFunction.GetCurrentDateTime;
        public DateTime ModifiedDate { get; set; } = CommonFunction.GetCurrentDateTime;
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
