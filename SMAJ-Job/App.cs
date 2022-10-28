using SMAJ_DAL.IRepository;
using SMAJ_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SMAJ_Job
{
    public class App
    {
        private IGenericRepository<DailyQuotes> _repository;
        public App(IGenericRepository<DailyQuotes> repository)
        {
            _repository = repository;
        }

        public async Task Run()
        {
            Console.WriteLine("Hello, World!");
        }

        public async Task CrawlerStockByDate(DateTime date)
        {
            using (HttpClient client = new())
            {
                string url = $"https://www.twse.com.tw/exchangeReport/MI_INDEX?response=json&date={date.ToString("yyyyMMdd")}&type=ALLBUT0999&_=1634182224496";
                var json = await client.GetStringAsync(url);
                var res = JsonSerializer.Deserialize<DailyQuotesInfo>(json);

                if (res.data9 is not null)
                {
                    try
                    {
                        res.data9.ForEach(item =>
                        {
                            _repository.Insert(
                                new DailyQuotes()
                                {
                                    StockID = item[0],
                                    StockName = item[1],
                                    TradeDate = date.Date,
                                    TradeVolume = item[2],
                                    TradeValue = item[3],
                                    TradeAmount = item[4],
                                    OpeningPrice = item[5],
                                    HighestPrice = item[6],
                                    LowestPrice = item[7],
                                    ClosingPrice = item[8],
                                    Dir = item[9],
                                    Change = item[10],
                                    LastBestBidPrice = item[11],
                                    LastBestBidVolume = item[12],
                                    LastBestAskPrice = item[13],
                                    LastBestAskVolume = item[14],
                                    PER = item[15]
                                });
                        });

                        _repository.Save();

                        // write log
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    // write log.
                }
            }
        }
    }
}
