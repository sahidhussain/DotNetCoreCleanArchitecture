using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Infrastructure.Generic;
using System;
using System.Collections.Generic;

namespace DotnetCore.Infrastructure.Data
{
    public class InstitutionRepository : IInstitutionRepository
    {
        
        public Institution Create(Institution entity)
        {
            try
            {
                return Create(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Institution> ListAll()
        {
            try
            {
                return ListAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
