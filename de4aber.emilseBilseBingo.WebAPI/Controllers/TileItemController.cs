using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmilseBilseBingo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TileItemController : Controller
    {
        private readonly ITileItemService _tileItemService;

        public TileItemController(ITileItemService tileItemService)
        {
            _tileItemService = tileItemService;
        }
        
        [HttpGet]
        public ActionResult<List<TileItem>> GetAll()
        {
            return _tileItemService.GetAll();
        }

        [HttpGet(nameof(GetById) + "/{id}")]
        public ActionResult<TileItem> GetById(int id)
        {
            return _tileItemService.GetById(id);
        }

        [HttpPost]
        public ActionResult<TileItem> Create(CreateTileItem tileItem)
        {
            return _tileItemService.Create(new TileItem(tileItem.Condition, tileItem.OfPersonId));
        }
    }

    public class CreateTileItem
    {
        public CreateTileItem(string condition, int ofPersonId)
        {
            Condition = condition;
            OfPersonId = ofPersonId;
        }

        public string Condition { get; set; }
        public int OfPersonId { get; set; }
    }
}