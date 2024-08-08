using AbonnementManager.Models;

namespace AbonnementManager.Repository.IRepository
{
    public interface IApplicationRepository : IRepository<Application>
    {
        void Update(Application obj);
    }

}
