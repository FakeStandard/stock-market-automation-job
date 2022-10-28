
namespace SMAJ_DAL.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save();
    }
}
