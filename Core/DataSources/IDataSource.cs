using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataSources;

public interface IDataSource<T> where T : class
{
    Task<T> Get();
    Task<IEnumerable<T>> GetVoxes();
    Task<IEnumerable<T>> GetMoreVoxes(int count);
}
