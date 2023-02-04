using Newtonsoft.Json;
using System;

namespace Voxed.WebApp.Models
{
    public class CommentStickyRequest
    {
        public string ContentType { get; set; }
        public Guid ContentId { get; set; }
        [JsonProperty("vox")]
        public string VoxId { get; set; }
    }
}
