using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class Command : EventArgs
    {

    }


    public class ChangeAgeCommand : Command
    {
        public int Age;
        public Person Target;

        public ChangeAgeCommand(Person p, int age)
        {
            Age = age;
            Target = p;
        }
    }
}
