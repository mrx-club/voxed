using System;

namespace Voxed.WebApp.Models
{
    public class FavoriteRequest
    {
        public int ContentType { get; set; }
        public Guid ContentId { get; set; }
    }
}
