using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Core.ApplicationServices.ServiceUser;
using DotnetCore.Core.DTO.DtoUser;
using DotnetCore.WebAPI.Helper;
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

        #region Sign In User
        [HttpPost]
        public ActionResult SignIn(SignInDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result =  _IUser.Authenticate(model);
                    if(!string.IsNullOrWhiteSpace(result.UserToken))
                    {
                        return Ok(result);
                    }

                    return new BadRequestObjectResult(Errors.AddErrorToModelState("InvalidUser", "Authentication failed!", ModelState));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region Create Role
        [HttpPost]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(roleName))
                {
                    var result = await _IUser.AddRoles(roleName);
                    return Ok(result);
                }
                else
                {
                    return new BadRequestObjectResult(Errors.AddErrorToModelState("BadInput", "Input is not valid", ModelState));
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}