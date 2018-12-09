using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Core.ApplicationServices.ServiceUser;
using DotnetCore.Core.DTO.DtoUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.WebAPI.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Private Fields
        private readonly IUserService _IUser;
        #endregion

        #region Constructor
        public AccountController(IUserService IUser)
        {
            _IUser = IUser;
        }
        #endregion

        #region Register User
        [HttpPost]
        public async Task<ActionResult> Register(CreateUserDto model)
        {
            try
            {
              var result = await _IUser.AddUser(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}