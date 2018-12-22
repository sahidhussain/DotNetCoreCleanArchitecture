using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.DTO.ApiResponse
{
    public class CreateTokenDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
        public string Email { get; set; }
        public string UserInRole { get; set; }
    }
}
