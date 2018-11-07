using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class EventBroker
    {
         public IList<Event> AllEvents = new List<Event>();

        public event EventHandler<Command> Commands;

        public event EventHandler<Query> Queries;
        public virtual void Command(Command e)
        {
            Commands?.Invoke(this, e);
        }

        public virtual int Query(Query e)
        {
            Queries?.Invoke(this, e);
            return e.Age;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangeEvent;
            if (ac  != null)
            {
                Command(new ChangeAgeCommand(ac.Target,ac.OldAge));
            }
        }
    }
}
