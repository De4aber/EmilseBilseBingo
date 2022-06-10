using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmilseBilseBingo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonThemeController: ControllerBase
    {
        private readonly IPersonThemeService _personThemeService;

        public PersonThemeController(IPersonThemeService personThemeService)
        {
            _personThemeService = personThemeService;
        }
        [HttpGet]
        public ActionResult<List<PersonTheme>> GetAll()
        {
            return _personThemeService.GetAll();
        }
        
    }
}