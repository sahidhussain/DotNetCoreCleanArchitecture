using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Infrastructure.Generic;
using System;
using System.Collections.Generic;

namespace DotnetCore.Infrastructure.Data
{
    public class InstitutionRepository : EFRepository<Institution>, IInstitutionRepository
    {

        public InstitutionRepository(ApplicationDbContext dbContext)
            :base(dbContext)
        {

        }
    }
}
