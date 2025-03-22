using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class PersonalDataReader
    {
        private readonly IDatabaseConnection _databaseConnection;

        public PersonalDataReader(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public string Read(int id)
        {
            Person person = _databaseConnection.GetById(id);
            return $"(Id: {person.Id}) {person.FirstName} {person.LastName}";
        }

        internal void Save(Person personToBeSaved)
        {
            throw new NotImplementedException();
        }
    }

}
