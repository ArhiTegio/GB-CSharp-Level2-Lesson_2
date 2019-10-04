using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFastDecisions;
using static System.Console;

namespace _1_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<BaseWorker>();
            var r = new Random();
            var company = new Company();

            var ex = new Extension();
            var q = new Questions();
            WriteLine("С# - Уровень 2. Задание 2.1");
            WriteLine("Кузнецов");
            WriteLine(
                "1. Построить  три  класса  (базовый  и  2  потомка),  описывающих  работников  с  почасовой  оплатой  (один  из  потомков)  и  фиксированной оплатой (второй потомок):" + Environment.NewLine +
                " a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»; " + Environment.NewLine +
                " b.Создать на базе абстрактного класса массив сотрудников и заполнить его; " + Environment.NewLine +
                " c.*Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort(); " + Environment.NewLine +
                " d.*Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach." + Environment.NewLine +
                "" + Environment.NewLine +
                "");

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
