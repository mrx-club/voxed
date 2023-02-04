using Core.Services.Storage.Models;
using System.Threading.Tasks;

namespace Core.Services.Storage
{
    public interface IStorage
    {
        Task Save(StorageObject obj);
    }
}
