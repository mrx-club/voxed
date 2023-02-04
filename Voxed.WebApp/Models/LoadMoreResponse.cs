using System.Collections.Generic;
using System.Linq;

namespace Voxed.WebApp.Models
{
    public class LoadMoreResponse : BaseResponse
    {
        public LoadMoreResponse(IEnumerable<VoxResponse> voxs)
        {
            Status = voxs.Any();
            List = new List()
            {
                Page = "category-sld",
                Voxs = voxs
            };
        }

        public List List { get; set; }
    }

    public class List
    {
        public IEnumerable<VoxResponse> Voxs { get; set; } = new List<VoxResponse>();
        public string Page { get; set; }
    }
}
