using System;

namespace Voxed.WebApp.Models
{
    public class CommentStickyResponse
    {
        public static class CommentStickyType
        {
            public const string RemoveAll = "REMOVE_ALL";
            public const string CommentSticky = "COMMENT_STICKY";
        }

        public string Type { get; set; } // REMOVE_ALL, COMMENT_STICKY
        public Guid Id { get; set; }
    }
}
