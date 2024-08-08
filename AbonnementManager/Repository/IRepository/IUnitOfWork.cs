
namespace AbonnementManager.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        IAbonnementRepository Abonnement { get; }
        IApplicationRepository Application { get; }

        void Save();
    }
}
