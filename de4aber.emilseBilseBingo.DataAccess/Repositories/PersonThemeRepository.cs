using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;
using MySqlConnector;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class PersonThemeRepository : IPersonThemeRepository
    {
        //Table
        private readonly string Table = "PersonTheme";
        
        //Rows
        private const string Id = "id";
        private const string Name = "color";
        private const string TakenByPersonId = "TakenByPersonId";

        
        private readonly MySqlConnection _connection = new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        public async Task<List<PersonTheme>> FindAll()
        {
            var list = new List<PersonTheme>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{Table}` ORDER BY `{Id}`;", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ent = new PersonTheme(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0),
                };
                var takenById = reader.GetValue(2);
                if (!takenById.Equals(null))
                {
                    ent.TakenByPersonId = (int) takenById;
                }
                
                list.Add(ent);
                
            }
            await _connection.CloseAsync();
            return list;
        }

        public Task<PersonTheme> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PersonTheme?> FindByPersonId(int id)
        {
            PersonTheme? ent = null;
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{Table}` WHERE `{TakenByPersonId}` = {id};", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ent = new PersonTheme(reader.GetValue(1).ToString())
                {
                    Id = (int) reader.GetValue(0),
                };
                var takenById = reader.GetValue(2);
                if (!takenById.Equals(null))
                {
                    ent.TakenByPersonId = (int) takenById;
                }
            }
            
            await _connection.CloseAsync();

            return ent;
        }

        public Task<PersonTheme> Create(PersonTheme person)
        {
            throw new System.NotImplementedException();
        }
    }
}