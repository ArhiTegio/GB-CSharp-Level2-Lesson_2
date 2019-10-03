using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Worker
{
    class Company : IEnumerable
    {
        List<BaseWorker> list = new List<BaseWorker>();

        public List<BaseWorker> List { get => list; set => list = value; }

        public IEnumerator GetEnumerator()
        {
            foreach (var t in List)
                yield return t;
        }

        public Company Sort()
        {
            list.Sort();
            return this;
        }
    }
}
