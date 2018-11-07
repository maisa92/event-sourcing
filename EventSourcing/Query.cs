using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class Query
    {
        public int Age { get; set; }
    }

    public class GetAgeQuery : Query
    {
       
        public Person Target { get; set; }

        public GetAgeQuery(Person p)
        {
            Target = p;
        }
    }
}
