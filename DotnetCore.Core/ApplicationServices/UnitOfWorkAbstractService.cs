using DotnetCore.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.ApplicationServices
{
   public abstract class UnitOfWorkAbstractService
    {
        protected IUnitOfWork _unitOfWork;

        public UnitOfWorkAbstractService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
