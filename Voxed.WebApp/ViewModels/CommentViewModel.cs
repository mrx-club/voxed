using Core.Entities;
using System;

namespace Voxed.WebApp.ViewModels
{
    public class CommentViewModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Hash { get; set; }
        public string Content { get; set; }
        public string AvatarColor { get; set; }
        public string AvatarText { get; set; }
        public bool IsOp { get; set; }
        public bool IsSticky { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int UserType { get; set; }
        public string Style { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public bool IsAdmin { get; set; }
        public MediaViewModel Media { get; set; }
    }
}
