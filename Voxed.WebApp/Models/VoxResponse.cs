namespace Voxed.WebApp.Models
{
    public class VoxResponse : BaseResponse, IBoardPostViewModel
    {
        //{
        //        "hash": "LVsFqy15CYaRdNXsv5jR",
        //        "status": "1",
        //        "niche": "20",
        //        "title": "Es verdad que las concha de tanto cojer se oscurecen? ",
        //        "comments": "101",
        //        "extension": "jpg",
        //        "sticky": "0",
        //        "createdAt": "2020-10-30 10:20:34",
        //        "pollOne": " Es por tanto cojer, mir\u00e1 te cuento ",
        //        "pollTwo": "Es por esto",
        //        "id": "20",
        //        "slug": "sld",
        //        "voxId": "405371",
        //        "new": false
        //}

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

    public interface IBoardPostViewModel
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
