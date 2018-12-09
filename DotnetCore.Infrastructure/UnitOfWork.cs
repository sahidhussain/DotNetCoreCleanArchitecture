using DotnetCore.Core.DomainServices;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region PRIVATE MEMBERS
        protected readonly ApplicationDbContext _dbContext;
        #endregion

        #region UNIT OF WORK: Constructor
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        private readonly IInstitutionRepository _IUOWInstitutionRepository;
        public IInstitutionRepository IUOWInstitutionRepository
        {
            //get
            //{
            //    _IUOWInstitutionRepository = new InstitutionRepository();
            //}
        }

        #region COMMIT
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion
    }
}
