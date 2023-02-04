using Core.Entities;
using System;

namespace Core.Services.Avatar
{
    public class AvatarService
    {
        private static readonly Random random = new();

        public static AvatarStyle GetAvatarStyle()
        {
            Array styles = Enum.GetValues(typeof(AvatarStyle));

            AvatarStyle style = (AvatarStyle)styles.GetValue(random.Next(styles.Length));

            while (style == AvatarStyle.White || style == AvatarStyle.Black)
            {
                style = (AvatarStyle)styles.GetValue(random.Next(styles.Length));
            }

            return style;
        }
    }
}
