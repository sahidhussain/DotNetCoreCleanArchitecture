using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
    public class InstituteDetail : BaseAddress
    {
        public long InstituteDetailId { get; set; }
        public string InstituteName { get; set; }

        public string Website { get; set; }
        public string Gender { get; set; }

        public long AppUserId { get; set; }
        public AppUsers AppUser { get; set; }

    }
}
