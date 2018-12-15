using AutoMapper;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.DTO.DtoUser;
using DotnetCore.Core.Entity;
using DotnetCore.Core.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.Core.ApplicationServices.ServiceUser
{
   public class UserService : IUserService
    {
        #region Private
        private readonly IUserRepository _iUserRepo;
        #endregion

        #region Constructor
        public UserService(IUserRepository iUserRepo)
        {
            _iUserRepo = iUserRepo;
        }
        #endregion

        #region Add User
        public Task<IdentityResult> AddUser(CreateUserDto dto)
        {
            try
            {
                AppUsers user = new AppUsers()
                {
                    Email = dto.Email,
                    UserName = dto.Email,
                    UserType = dto.UserType
                };
                string role = GetRole(dto.UserType);
                return _iUserRepo.AddUser(user, dto.Password, role);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Roles
        public Task<IdentityResult> AddRoles(string roleName)
        {
            try
            {
                AppRole role = new AppRole()
                {
                   Name = roleName
                };
                return _iUserRepo.AddRoles(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SWITCH
        private string GetRole(int userType)
        {
            string role = string.Empty;

            switch(userType)
            {
                case 1:
                    role= Constants.ROLESUPERADMIN;
                    break;
                case 2:
                    role = Constants.ROLEADMIN;
                    break;
                default:
                    role = Constants.ROLENORMALUSER;
                    break;
            }
            return role;
        }
        #endregion
    }
}
