using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class Command : EventArgs
    {
        public bool Represent { get; set; } = true;
    }


    public class ChangeAgeCommand : Command
    {
        public int Age;
        public Person Target;

        public ChangeAgeCommand(Person p, int age, bool represent = true)
        {
            Age = age;
            Target = p;
            Represent = represent;
        }
    }
}
