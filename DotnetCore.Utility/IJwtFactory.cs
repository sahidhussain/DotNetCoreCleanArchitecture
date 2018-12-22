using DotnetCore.Core.DTO.ApiResponse;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.Utility
{
    public interface IJwtFactory
    {
        #region INTERFACE: Create JWT Token
        string GetJwtToken(CreateTokenDto dto);
        #endregion

        #region INTERFACE: Get User Id From JWT Token
        string GetUserIdFromToken(HttpContext context);
        #endregion

    }
}
