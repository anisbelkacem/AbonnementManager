using AbonnementManager.Models;

namespace AbonnementManager.Repository.IRepository
{
    public interface IAbonnementRepository : IRepository<Abonnement>
    {
        void Update(Abonnement obj);
    }

}
