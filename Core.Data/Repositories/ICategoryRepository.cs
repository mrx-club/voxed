using Core.Entities;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> Exists(int id);
        Task<bool> Exists(string category);
        Task<Category> GetByShortName(string shortName);
    }
}
