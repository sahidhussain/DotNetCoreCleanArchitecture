using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Core.Utility;
using Microsoft.AspNetCore.Identity;
using System;
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


    }
}
