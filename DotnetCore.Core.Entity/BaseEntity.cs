using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
   public abstract class BaseEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
