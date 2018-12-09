using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.DTO.DtoInstitute
{
    public class CreateInstituteDto
    {
        public string InstitutionName { get; set; }
        public string InstitutionLogo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
    }
}
