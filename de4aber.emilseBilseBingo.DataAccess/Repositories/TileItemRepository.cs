using System.Collections.Generic;
using System.Linq;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.DataAcess.Entities;
using de4aber.emilseBilseBingo.Domain.IRepositories;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class TileItemRepository: ITileItemRepository
    {

        private readonly MainDbContext _ctx;

        public TileItemRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<TileItem> FindAll()
        {
            return _ctx.TileItemEntities.Select(tie => tie.ToTileItem()).ToList();
        }
    }
}