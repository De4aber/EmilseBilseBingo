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
        //Table
        private readonly string Table = "Person";
        
        //Rows
        private const string Id = "id";
        private const string Name = "name";

        private readonly MySqlConnection _connection = new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        
        public async Task<List<Person>> FindAll()
        {
            var list = new List<Person>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{Table}` ORDER BY `{Id}`;", _connection);
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
            await _connection.CloseAsync();
            return list;
        }

        public async Task<Person> FindById(int id)
        {
            Person ent = null;
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{Table}` WHERE `{Id}` = {id};", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ent = new Person(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
                
            }
            
            await _connection.CloseAsync();
            if (ent == null)
            {
                throw new InvalidDataException("user with that id does not exist");
            }

            return ent;
        }

        public async Task<Person> Create(Person person)
        {
            Person? ent = null;
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"INSERT INTO `{Table}`(`{Name}`) VALUES ('{person.Name}'); SELECT * FROM `{Table}` WHERE `{Id}` = LAST_INSERT_ID();", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ent = new Person(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0)
                };
            }
            
            await _connection.CloseAsync();
            if (ent == null)
            {
                throw new InvalidDataException("user with that id does not exist");
            }
            return ent;
        }
    }
}