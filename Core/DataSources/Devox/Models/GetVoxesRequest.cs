using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataSources.Devox.Models
{
    public class GetVoxesRequest
    {
        public object User { get; set; }
        public int Count { get; set; }
        public int OldCount { get; set; }
    }
}
