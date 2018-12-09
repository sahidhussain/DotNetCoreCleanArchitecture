using DotnetCore.Core.DomainServices.IData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.DomainServices
{
    public interface IUnitOfWork :IDisposable
    {
        IInstitutionRepository IUOWInstitutionRepository { get; }

        #region COMMIT
        int Commit();
        #endregion

    }
}
