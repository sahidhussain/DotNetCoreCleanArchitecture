using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
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
        #endregion

        #region Constructor
        public UserRepository(UserManager<AppUsers> userManager, RoleManager<AppRole> roleManager, ApplicationIdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _identityDbContext = identityDbContext;
        }
        #endregion

        #region REPOSITORY: ADD USER
        public async Task<IdentityResult> AddUser(AppUsers user, string userPassword)
        {
            try
            {
                return await _userManager.CreateAsync(user, userPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
