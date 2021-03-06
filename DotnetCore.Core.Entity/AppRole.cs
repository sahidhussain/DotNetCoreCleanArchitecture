﻿using DotnetCore.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Entity
{
    public class AppRole : IdentityRole<long>
    {
        public bool IsActive { get; set; } = CommonFunction.GetStatusTrue;
        public DateTime CreatedDate { get; set; } = CommonFunction.GetCurrentDateTime;
        public DateTime ModifiedDate { get; set; } = CommonFunction.GetCurrentDateTime;
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }

    }
}
