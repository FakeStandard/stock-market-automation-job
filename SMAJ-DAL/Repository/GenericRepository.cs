using Microsoft.EntityFrameworkCore;
using SMAJ_DAL.IRepository;

namespace SMAJ_DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StockDataCollectionContext context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(StockDataCollectionContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> Get() => dbSet.ToList();

        public T GetById(object id) => dbSet.Find(id);

        public void Insert(T entity) => dbSet.Add(entity);

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entity = this.GetById(id);

            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
