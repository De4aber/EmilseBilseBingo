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