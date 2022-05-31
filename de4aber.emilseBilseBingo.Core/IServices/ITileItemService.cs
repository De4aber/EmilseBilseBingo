using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface ITileItemService
    {
        public List<TileItem> GetAll();

        public TileItem Create(TileItem tileItem);
    }
}