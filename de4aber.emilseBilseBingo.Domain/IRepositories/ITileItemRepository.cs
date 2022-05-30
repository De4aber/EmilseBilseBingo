using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface ITileItemRepository
    {
        public List<TileItem> FindAll();
    }
}