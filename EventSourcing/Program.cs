using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            EventBroker ev = new EventBroker();
            Person p = new Person(ev);
            ev.Command(new ChangeAgeCommand(p,123));

            var age =  ev.Query(new GetAgeQuery(p));

            foreach (var e in ev.AllEvents)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(age);
            ev.UndoLast();
            Console.WriteLine(ev.Query(new GetAgeQuery(p)));
            foreach (var e in ev.AllEvents)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }
    }
}
