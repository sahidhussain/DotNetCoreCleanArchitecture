using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
   public class UserDetail
    {
        public long UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long AppUserId { get; set; }
        public AppUsers AppUser { get; set; }
    }
}
