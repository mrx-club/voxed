using System.Collections.Generic;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.ViewModels
{
    public class BoardViewModel
    {
        public IEnumerable<IBoardPostViewModel> Voxs { get; set; }
        public string Page { get; set; }
        public string Title { get; set; }
    }
}
