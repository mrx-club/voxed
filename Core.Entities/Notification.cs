using System;

namespace Core.Entities
{
    public enum NotificationType { New, Reply }

    public class Notification : Entity
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid CommentId { get; set; }
        public NotificationType Type { get; set; }
        public virtual User Owner { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
