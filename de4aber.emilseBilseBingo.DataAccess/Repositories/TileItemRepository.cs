using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;
using MySqlConnector;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class TileItemRepository: ITileItemRepository
    {

        private string _table = "TileItem";
        private readonly MySqlConnection _connection = new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        
        public async Task<List<TileItem>> FindAll()
        {
            var list = new List<TileItem>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{_table}` ORDER BY `id`;", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ent = new TileItem(reader.GetValue(1).ToString(), (int) reader.GetValue(2))
                {
                    Id = (int) reader.GetValue(0)
                };
                list.Add(ent);
                
            }

            return list;
        }

        public async Task<TileItem> FindById(int id)
        {
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"SELECT * FROM `{_table}` WHERE `id` = {id};", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ent = new TileItem(reader.GetValue(1).ToString(),(int) reader.GetValue(2))
                {
                    Id = (int) reader.GetValue(0)
                };
                return ent;

            }

            throw new InvalidDataException("TileItem with that id does not exist");
        }

        public async Task<TileItem> Create(TileItem tileItem)
        {
            await _connection.OpenAsync();

            await using var command = new MySqlCommand($"INSERT INTO `{_table}`(`bingoCondition`, `ofPersonId`) VALUES ('{tileItem.Condition}', '{tileItem.OfPersonId}'); SELECT * FROM `{_table}` WHERE `id` = LAST_INSERT_ID();", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ent = new TileItem(reader.GetValue(1).ToString(),(int) reader.GetValue(2))
                {
                    Id = (int) reader.GetValue(0)
                };
                return ent;

            }

            throw new InvalidDataException("ERROR: TileItem not created");
        }
    }
}