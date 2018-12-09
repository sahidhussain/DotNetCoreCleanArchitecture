using DotnetCore.Core.DTO.DtoInstitute;
using DotnetCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.ApplicationServices.InstitutionServce
{
    public interface IInstituteService
    {
         Institution Create(CreateInstituteDto entity);
         IEnumerable<Institution> ListAll();
    }
}
