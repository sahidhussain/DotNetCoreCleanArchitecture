using DotnetCore.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.DTO.DtoUser
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UserType { get; set; }
    }
}
