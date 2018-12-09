using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
   public class AppUsers :IdentityUser<long>
    {
        public int UserType { get; set; }
        public long? FacebookId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}
