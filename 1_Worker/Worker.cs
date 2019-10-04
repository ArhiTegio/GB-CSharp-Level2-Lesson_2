using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Worker
{
    /// <summary>
    /// Базовый класс работников
    /// </summary>
    public abstract class BaseWorker : IComparable<BaseWorker>
    {
        double rate = 0;
        public BaseWorker(string Name, int Age, int Salary, double rate)
        {
            this.Name = Name;
            this.Age = Age;
            this.Salary = Salary;
            this.rate = rate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public double Rate { get => rate; set => rate = value; }

        /// <summary>
        /// Зарплата за месяц
        /// </summary>
        /// <returns></returns>
        public abstract double PaymentInManth();

        /// <summary>
        /// Данные о работнике
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name}, {this.Age} лет,  {this.Salary} р. ";
        }

        /// <summary>
        /// Сравнение двух работников
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(BaseWorker obj) 
        {
            return obj.Salary > this.Salary ? -1 : 1;
        }

    }
    
    /// <summary>
    /// Работники с почасовой оплатой труда
    /// </summary>
    public class WageWorker : BaseWorker
    {
        public WageWorker(string Name, int Age, int Salary, double rate) : base(Name, Age, Salary, rate)
        {
        }

        public override double PaymentInManth()
        {
            Salary = (int)(20.8 * 8 * Rate);
            return Salary;
        }
    }

    /// <summary>
    /// Работники с фиксированной оплатой труда
    /// </summary>
    public class АixedSalaryWorker : BaseWorker
    {
        public АixedSalaryWorker(string Name, int Age, int Salary, double rate) : base(Name, Age, Salary, rate)
        {
        }

        public override double PaymentInManth()
        {
            Salary = (int)Rate;
            return Salary;
        }
    }


}
