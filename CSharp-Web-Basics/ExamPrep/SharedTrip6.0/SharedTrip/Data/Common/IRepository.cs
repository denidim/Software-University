using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SharedTrip.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        int SaveChanges();
    }
}
