using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Worker
{
    public abstract class BaseWorker : IComparable
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

        public abstract double PaymentInManth();

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Salary} ";
        }

        public int CompareTo(object obj)
        {
            var other = obj as BaseWorker;
            return other.Salary > this.Salary ? -1 : 1;
        }

    }

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
