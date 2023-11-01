using System;
using System.Collections.Generic;

namespace UserServiceApi.Models
{
    public partial class User
    {
        public User()
        {
        }

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
