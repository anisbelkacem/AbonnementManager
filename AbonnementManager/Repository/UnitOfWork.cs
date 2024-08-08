using AbonnementManager.Data;
using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;

namespace AbonnementManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IClientRepository Client { get; private set; }
        public IApplicationRepository Application { get; private set; }
        public IAbonnementRepository Abonnement { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db; 
            Client = new ClientRepository(_db);
            Application = new ApplicationRepository(_db);
            Abonnement = new AbonnementRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
