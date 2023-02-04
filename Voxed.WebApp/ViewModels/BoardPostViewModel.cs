using Voxed.WebApp.Models;

namespace Voxed.WebApp.ViewModels
{
    public class BoardPostViewModel : IBoardPostViewModel
    {
        public string Hash { get; set; }
        public string Niche { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public string Extension { get; set; }
        public string Sticky { get; set; }
        public string CreatedAt { get; set; }
        public string PollOne { get; set; }
        public string PollTwo { get; set; }
        public string Id { get; set; }
        public string Slug { get; set; }
        public string VoxId { get; set; }
        public bool New { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Category { get; set; }
        public string Href { get; set; }
    }
}
