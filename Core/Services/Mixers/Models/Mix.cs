using System.Collections.Generic;

namespace Core.Services.Mixers.Models
{
    public interface IMix<T> where T : class
    {
        List<T> Items { get; set; }
    }

    public class Mix : IMix<MixItem>
    {
        public List<MixItem> Items { get; set; } = new List<MixItem>();
    }

}
