using Microsoft.EntityFrameworkCore;
using SMAJ_Model;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyQuotes>().ToTable("DailyQuotes");
            //modelBuilder.Entity<OrderDetail>()
            //    .ToTable("OrderDetails")
            //    .HasKey(k => new { k.OrderID, k.ProductID });
        }
    }
}
