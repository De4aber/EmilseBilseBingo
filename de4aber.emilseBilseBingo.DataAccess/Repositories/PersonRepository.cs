using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.DataAcess.Entities;
using de4aber.emilseBilseBingo.Domain.IRepositories;
using MySqlConnector;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySqlConnection _connection;

        public PersonRepository(MySqlConnection connection)
        {
            _connection =
                new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        }

        public async Task<List<Person>> FindAll()
        {

            var list = new List<Person>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand("SELECT * FROM `Person`;", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                var ent = new PersonEntity(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
                Console.WriteLine("value = " + value);
                list.Add(ent.ToPerson());
                
            }

            return list;
        }

        public Person FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        private PersonEntity ToEntity(Person person)
        {
            return new PersonEntity(person.Name);
        }
    }
}