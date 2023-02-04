using System;
using System.Collections.Generic;

namespace Voxed.WebApp.ViewModels
{
    public enum UserType { Anonymous, Administrator, Moderator, Account, AnonymousAccount }

    public class VoxDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Hash { get; set; }
        public string CategoryShortName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryThumbnailUrl { get; set; }
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public string Poll { get; set; }
        public int CommentsCount { get; set; }
        public int CommentsAttachmentCount { get; set; }
        public string CreatedOn { get; set; }
        public string CommentTag { get; set; }
        public MediaViewModel Media { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public bool IsFollowed { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsHidden { get; set; }
    }
}
