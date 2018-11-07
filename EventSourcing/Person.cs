using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class Person
    {
        private int _age;
        private readonly EventBroker _eventBroker;
        
        public Person(EventBroker brocker)
        {
            _eventBroker = brocker;
            _eventBroker.Commands += EventBrokerOnCommands;
            _eventBroker.Queries += EventBrokerOnQueries;
        }

        private void EventBrokerOnQueries(object sender, Query query)
        {
            var q = query as GetAgeQuery;
            if (q != null && q.Target == this)
            {
                q.Age = _age; 
            }
        }

        private void EventBrokerOnCommands(object sender, Command command)
        {
            var com = command as ChangeAgeCommand;

            if (com != null && com.Target == this)
            {   
                _eventBroker.AllEvents.Add(new AgeChangeEvent(this,_age,com.Age));
                _age = com.Age;
            }
        }
    }
}
