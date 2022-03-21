using System.Threading.Tasks;

namespace ReportsDAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportsDbContext _dbContext;

        public UnitOfWork(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}