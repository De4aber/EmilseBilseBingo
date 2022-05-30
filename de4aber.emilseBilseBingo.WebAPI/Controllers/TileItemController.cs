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
    }
}