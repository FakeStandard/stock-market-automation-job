using SMAJ_DAL.IRepository;
using SMAJ_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
