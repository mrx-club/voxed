using Core.Entities;
using System.Collections.Generic;

namespace Core.Shared
{
    public class UserTypeDictionary
    {
        private static Dictionary<UserType, string> _description = new()
        {
            { UserType.Anonymous, "anon" },
            { UserType.Administrator, "admin" },
            { UserType.Moderator, "mod" },
            { UserType.Account, "anon" },
            { UserType.AnonymousAccount, "anon" },
            { UserType.Developer, "dev" },
        };

        public static string GetDescription(UserType code)
            => _description[code];
    }
}
