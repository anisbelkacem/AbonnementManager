using AbonnementManager.Data;
using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;

namespace AbonnementManager.Repository
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        private AppDbContext _db;
        public ApplicationRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Application obj)
        {
            _db.applications.Update(obj);
        }
    }
}
