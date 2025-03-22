using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public Person GetById(int id = 1)
        {
            return new Person
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe"
            };
        }
    }  
}

