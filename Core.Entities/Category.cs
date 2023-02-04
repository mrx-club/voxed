using System;

namespace Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool Nsfw { get; set; }
        public Guid MediaId { get; set; }
        public Media Media { get; set; }
    }
}
