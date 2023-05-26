using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IThietBiSuaChuaRepository : IRepository<ThietBiSuaChua>
    {

    }
    public class ThietBiSuaChuaRepository : Repository<ThietBiSuaChua>, IThietBiSuaChuaRepository
    {
        public ThietBiSuaChuaRepository(MyDbContext _db) : base(_db)
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