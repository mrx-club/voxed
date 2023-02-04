using System;

namespace Core.Entities
{
    public class UserPostAction : Entity
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public bool IsFollowed { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsHidden { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
