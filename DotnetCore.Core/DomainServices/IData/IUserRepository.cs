using DotnetCore.Core.DTO.DtoUser;
using DotnetCore.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.Core.DomainServices.IData
{
    public interface IUserRepository
    {
        #region Add User
        Task<IdentityResult> AddUser(AppUsers dto, string userPassword);
        #endregion
    }
}
