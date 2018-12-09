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
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; } = 0;
        public long ModifiedBy { get; set; } = 0;
    }
}
