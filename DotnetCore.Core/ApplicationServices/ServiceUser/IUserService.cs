using DotnetCore.Core.DTO.ApiResponse;
using DotnetCore.Core.DTO.DtoUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.Core.ApplicationServices.ServiceUser
{
    public interface IUserService
    {
        #region Add User
        Task<IdentityResult> AddUser(CreateUserDto dto);
        #endregion

        #region Add Role
        Task<IdentityResult> AddRoles(string roleName);
        #endregion

        #region Add Role
        Token Authenticate(SignInDto dto);
        #endregion

    }
}
