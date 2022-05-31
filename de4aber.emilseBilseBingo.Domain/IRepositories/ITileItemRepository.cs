using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface ITileItemRepository
    {
        public Task<List<TileItem>> FindAll();

        public TileItem FindById(int id);

        public TileItem Create(TileItem tileItem);
    }
}