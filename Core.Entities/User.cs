using Microsoft.AspNetCore.Identity;
using System;

namespace Core.Entities
{
    public enum UserType { Anonymous, Administrator, Moderator, Account, AnonymousAccount, Developer }

    public class User : IdentityUser<Guid>
    {
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public UserType UserType { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string Token { get; set; }
    }
}
