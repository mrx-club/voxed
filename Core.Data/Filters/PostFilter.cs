using System;
using System.Collections.Generic;

namespace Core.Data.Filters
{
    public class PostFilter
    {
        public Guid? UserId { get; set; }
        public IEnumerable<int> Categories { get; set; } = new List<int>();
        public IEnumerable<Guid> IgnorePostIds { get; set; } = new List<Guid>();
        public IEnumerable<string> HiddenWords { get; set; } = new List<string>();
        public string SearchText { get; set; }
        public bool IncludeHidden { get; set; }
        public bool IncludeFavorites { get; set; }
    }
}
