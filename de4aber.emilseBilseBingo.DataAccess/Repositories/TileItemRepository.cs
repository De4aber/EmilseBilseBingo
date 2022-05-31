using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.DataAcess.Entities;
using de4aber.emilseBilseBingo.Domain.IRepositories;
using MySqlConnector;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class TileItemRepository: ITileItemRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection("Server=185.51.76.204; Database=EmilseBilseBingo; Uid=root; PWD=hemmeligt;");
        private readonly MainDbContext _ctx;

        public TileItemRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<TileItem>> FindAll()
        {
            var list = new List<TileItem>();
            await _connection.OpenAsync();

            await using var command = new MySqlCommand("SELECT * FROM `TileItem` ORDER BY `id`;", _connection);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                var ent = new TileItemEntity(reader.GetValue(1).ToString(), (int) reader.GetValue(2))
                {
                    Id = (int) reader.GetValue(0)
                };
                list.Add(ent.ToTileItem());
                
            }

            return list;
        }

        public TileItem FindById(int id)
        {
            return _ctx.TileItemEntities.First(t => t.Id == id).ToTileItem();
        }

        public TileItem Create(TileItem tileItem)
        {
            var tI = _ctx.TileItemEntities.Add(toTileEntity(tileItem)).Entity;
            _ctx.SaveChanges();
            return tI.ToTileItem();
        }

        private TileItemEntity toTileEntity(TileItem tileItem)
        {
            return new TileItemEntity(tileItem.Condition, tileItem.OfPersonId);
        }
    }
}