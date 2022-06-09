using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface ITileItemRepository
    {
        public Task<List<TileItem>> FindAll();
        
        public Task<List<TileItem>> FindByPersonId(int personId);

        public Task<TileItem> FindById(int id);

        public Task<TileItem> Create(TileItem tileItem);
        
    }
}