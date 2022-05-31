using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;
using MySqlConnector;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private string _table = "Person";
        private readonly MySqlConnection _connection = new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        
        public async Task<List<Person>> FindAll()
        {
            var list = new List<Person>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{_table}` ORDER BY `id`;", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                var ent = new Person(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
                list.Add(ent);
                
            }

            return list;
        }

        public async Task<Person> FindById(int id)
        {
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{_table}` WHERE `id` = {id};", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                var ent = new Person(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
                return ent;

            }

            throw new InvalidDataException("user with that id does not exist");
        }

        public async Task<Person> Create(Person person)
        {
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"INSERT INTO `{_table}`(`name`) VALUES ('{person.Name}'); SELECT * FROM `{_table}` WHERE `id` = LAST_INSERT_ID();", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ent = new Person(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
                return ent;

            }

            throw new InvalidDataException("ERROR: person not created");
        }
    }
}