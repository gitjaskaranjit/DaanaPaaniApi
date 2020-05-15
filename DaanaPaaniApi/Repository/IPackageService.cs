using DaanaPaaniApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IPackageService
    {
        IQueryable<Package> getAll();

        Task<Package> getById(int id);

        Task<Package> add(Package package);

        Task<Package> update(int id, Package packge);

        Task<Package> delete(Package package);
    }
}