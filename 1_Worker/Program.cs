using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Worker
{
    class Program
    {
        static void Main(string[] args)
        { 
            var list = new List<BaseWorker>();
            var r = new Random();
            var company = new Company();
            for (int i = 0; i < 50; ++i)
            {
                if(r.Next(0,1) == 0)
                    list.Add(new WageWorker($"Worker{i}", r.Next(18, 100), r.Next(100000, 10000000), r.Next(10000, 1000000)));
            }
            company.List = list;
            foreach (var t in company)
                Console.WriteLine(t);


            Console.WriteLine("-------------------------------------------------------");
            company.Sort();

            foreach (var t in company)            
                Console.WriteLine(t);

            Console.ReadLine();



        }
    }

   
}
