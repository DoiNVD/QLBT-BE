using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IThucHienBaoTriRepository : IRepository<ThucHienBaoTri>
    {

    }
    public class ThucHienBaoTriRepository : Repository<ThucHienBaoTri>, IThucHienBaoTriRepository
    {
        public ThucHienBaoTriRepository(MyDbContext _db) : base(_db)
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
