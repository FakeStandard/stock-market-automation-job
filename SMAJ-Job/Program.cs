
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMAJ_DAL;
using SMAJ_DAL.IRepository;
using SMAJ_DAL.Repository;
using SMAJ_Job;
using SMAJ_Model;

// 建立依賴注入容器
var services = new ServiceCollection();

// 註冊DB連線
services.AddDbContext<StockDataCollectionContext>();

// 註冊服務
services.AddTransient<App>();
services.AddTransient<IGenericRepository<DailyQuotes>, GenericRepository<DailyQuotes>>();

// 建立依賴服務提供者
var provider = services.BuildServiceProvider();

// 執行主服務
provider.GetRequiredService<App>().Run();

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
