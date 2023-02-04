using Microsoft.AspNetCore.Http;
using System;

namespace Core.Services.Posts.Models
{
    public class CreatePostRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string Extension { get; set; }
        public string ExtensionData { get; set; }
        public IFormFile File { get; set; }
    }
}
