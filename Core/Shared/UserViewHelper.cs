using Core.Entities;
using System;

namespace Core.Shared
{
    public static class UserViewHelper
    {
        public static string GetUserName(User user)
        {
            return user.UserType switch
            {
                UserType.Anonymous => "Anonimo",
                UserType.Administrator => user.UserName,
                UserType.Moderator => "Anonimo",
                UserType.Account => "Anonimo",
                UserType.AnonymousAccount => "Anonimo",
                UserType.Developer => "Anonimo",
                _ => throw new NotImplementedException("Tipo de usuario no contemplado"),
            };
        }

        public static string GetUserTypeTag(UserType userType)
        {
            return UserTypeDictionary.GetDescription(userType).ToLower();
        }
    }
}
