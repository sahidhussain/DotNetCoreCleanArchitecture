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
        Task<IdentityResult> AddUser(AppUsers dto, string userPassword, string role = "");
        #endregion

        #region Add Role
        Task<IdentityResult> AddRoles(AppRole roleName);
        #endregion

        #region User Authentication
        Task<SignInResult> Authenticate(AppUsers users, string password);
        #endregion

        #region Get User By Email
        Task<AppUsers> GetUserByEmail(string email);
        #endregion

        #region Get User In Role
        Task<IList<string>> GetUserInRole(AppUsers users);
        #endregion
    }
}
