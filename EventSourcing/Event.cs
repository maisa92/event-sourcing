using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class Event
    {
      
    }

    public class AgeChangeEvent : Event
    {
        public Person Target;
        public int OldAge;
        public int NewAge;

        public AgeChangeEvent(Person target, int oldAge, int newAge)
        {
            Target = target;
            OldAge = oldAge;
            NewAge = newAge;
        }

        public override string ToString()
        {
            return $"Age change from {OldAge} to {NewAge}";
        }
    }
}
