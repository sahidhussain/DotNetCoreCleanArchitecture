using AutoMapper;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.DTO.DtoUser;
using DotnetCore.Core.Entity;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _iUserRepo;
        
        #endregion
        public UserService(IUserRepository iUserRepo)
        {
            _iUserRepo = iUserRepo;
        }

        #region Add User
        public Task<IdentityResult> AddUser(CreateUserDto dto)
        {
            try
            {
                //var userIdentity = _mapper.Map<AppUsers>(dto);
                AppUsers user = new AppUsers()
                {
                    Email = dto.Email,
                    UserName = dto.Email
                };

                return _iUserRepo.AddUser(user, dto.Password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
