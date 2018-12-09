using DotnetCore.Core.DomainServices;
using DotnetCore.Core.DTO.DtoInstitute;
using DotnetCore.Core.Entity;
using System;
using System.Collections.Generic;

namespace DotnetCore.Core.ApplicationServices.InstitutionServce
{
    public class InstituteService : UnitOfWorkAbstractService, IInstituteService
    {
        public InstituteService(IUnitOfWork _unitOfWork) : base(_unitOfWork) { }

        public Institution Create(CreateInstituteDto model)
        {
            try {
                Institution entity = new Institution()
                {
                    InstitutionId = Guid.NewGuid(),
                    InstitutionName = model.InstitutionName,
                    Address = model.Address,
                    City = model.City,
                    StateId = model.StateId,
                    CountryId = model.CountryId,
                    ZipCode = model.ZipCode,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedBy = Guid.NewGuid()
                };

                var createdCustomer = _unitOfWork.IUOWInstitutionRepository.Create(entity);
                _unitOfWork.Commit();
                return createdCustomer;

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
                return _unitOfWork.IUOWInstitutionRepository.ListAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
