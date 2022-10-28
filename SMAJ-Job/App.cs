using SMAJ_DAL.IRepository;
using SMAJ_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Run()
        {
            var data = _repository.Get();

            Console.WriteLine("Hello, World!");
        }
    }
}
