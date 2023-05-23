using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IHuyBaoTriRepository : IRepository<HuyBaoTri>
    {

    }
    public class HuyBaoTriRepository : Repository<HuyBaoTri>, IHuyBaoTriRepository
    {
        public HuyBaoTriRepository(MyDbContext _db) : base(_db)
        {
        }
        public MyDbContext MyDbContext
        {
            get
            {
                return _db as MyDbContext;
            }
        }


    }
}