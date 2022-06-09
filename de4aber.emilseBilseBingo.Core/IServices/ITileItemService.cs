using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface ITileItemService
    {
        public List<TileItem> GetAll();

        public List<TileItem> GetAll_Random();
        
        public List<TileItem> GetByPersonId(int id);

        public TileItem GetById(int id);

        public TileItem Create(TileItem tileItem);
    }
}