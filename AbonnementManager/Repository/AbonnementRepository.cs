using AbonnementManager.Data;
using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;

namespace AbonnementManager.Repository
{
    public class AbonnementRepository : Repository<Abonnement>, IAbonnementRepository
    {
        private AppDbContext _db;
        public AbonnementRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Abonnement obj)
        {
            _db.abonnements.Update(obj);
        }
    }
}
