using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Core.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetCore.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        #region Private Members
        private ApplicationIdentityDbContext _identityDbContext;
        private UserManager<AppUsers> _userManager;
        private RoleManager<AppRole> _roleManager;
        private SignInManager<AppUsers> _signInManager;
        #endregion

        #region Constructor
        public UserRepository(UserManager<AppUsers> userManager,
                                RoleManager<AppRole> roleManager,
                                SignInManager<AppUsers> signInManager,
                                ApplicationIdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _identityDbContext = identityDbContext;
        }
        #endregion

        #region REPOSITORY: ADD USER
        public async Task<IdentityResult> AddUser(AppUsers user, string userPassword, string role ="")
        {
            try
            {
                var result = await _userManager.CreateAsync(user, userPassword);
                if(result.Succeeded)
                {
                    await AddUserToRole(user, role); 
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region REPOSITORY: ADD ROLES
        public async Task<IdentityResult> AddRoles(AppRole roleName)
        {
            try
            {
                IdentityResult result = null;

                var isExist = await _roleManager.RoleExistsAsync(roleName.Name);
                if(!isExist)
                {
                    result= await _roleManager.CreateAsync(roleName);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region REPOSITORY: ADD USER TO ROLE
        public async Task<IdentityResult> AddUserToRole(AppUsers user, string roleName)
        {
            try
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region REPOSITORY: AUTHENTICATION
        public async Task<SignInResult> Authenticate(AppUsers users, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(users.UserName, password, isPersistent: true, lockoutOnFailure: false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region REPOSITORY: GET USER BY EMAIL
        public async Task<AppUsers> GetUserByEmail(string email)
        {
            try
            {
                return await _userManager.FindByEmailAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region REPOSITORY: GET USER IN ROLE
        public async Task<IList<string>> GetUserInRole(AppUsers users)
        {
            try
            {
                return await _userManager.GetRolesAsync(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
