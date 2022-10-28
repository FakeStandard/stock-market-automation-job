using Microsoft.EntityFrameworkCore;
using SMAJ_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMAJ_DAL
{
    public class StockDataCollectionContext : DbContext
    {
        public StockDataCollectionContext(DbContextOptions<StockDataCollectionContext> options)
            : base(options)
        {

        }

        public DbSet<DailyQuotes> DailyQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(Localdb)\MSSQLLocalDB;Initial Catalog=StockDataCollection;Integrated Security=True");
        }
    }
}
