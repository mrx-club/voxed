using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public enum PostState { Active, Deleted, Reported }

    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
        public PostState State { get; set; }
        public bool IsSticky { get; set; }
        public DateTimeOffset LastActivityOn { get; set; } = DateTimeOffset.Now;
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public virtual Media Media { get; set; }
        public virtual Category Category { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();        
    }
}
