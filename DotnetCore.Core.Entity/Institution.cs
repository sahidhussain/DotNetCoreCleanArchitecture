﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetCore.Core.Entity
{
    [Table("Institution")]
    public class Institution : BaseEntity
    {
        public Guid InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionLogo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
    }
}
