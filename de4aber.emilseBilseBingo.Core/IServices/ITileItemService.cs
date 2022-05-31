using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface ITileItemService
    {
        public Task<List<TileItem>> GetAll();

        public TileItem GetById(int id);

        public TileItem Create(TileItem tileItem);
    }
}