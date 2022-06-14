using System.Threading.Tasks;

namespace Kol2_example.Services
{
    public interface IDbService
    {
        Task<object> GetMusician(int idMusician);
        Task<bool> RemoveMusician(int idMusician);
    }
}
