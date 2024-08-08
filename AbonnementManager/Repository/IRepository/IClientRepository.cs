using AbonnementManager.Models;

namespace AbonnementManager.Repository.IRepository
{
    public interface IClientRepository : IRepository<Client>
    {
        void Update(Client obj);
    }

}
