using AbonnementManager.Data;
using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;

namespace AbonnementManager.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private AppDbContext _db;
        public ClientRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Client obj)
        {
            _db.clients.Update(obj);
        }
    }
}
