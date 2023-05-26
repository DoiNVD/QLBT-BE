using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface ILoiThietBiSuaChuaRepository : IRepository<LoiThietBiSuaChua>
    {

    }
    public class LoiThietBiSuaChuaRepository : Repository<LoiThietBiSuaChua>, ILoiThietBiSuaChuaRepository
    {
        public LoiThietBiSuaChuaRepository(MyDbContext _db) : base(_db)
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
