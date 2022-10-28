using SMAJ_DAL.IRepository;
using SMAJ_Model;

namespace SMAJ_DAL.Repository
{
    public class DailyQuotesRepository : GenericRepository<DailyQuotes>, IDailyQuotesRepository
    {
        public DailyQuotesRepository(
            StockDataCollectionContext context)
            : base(context)
        {

        }
    }
}
