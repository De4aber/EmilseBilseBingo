using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmilseBilseBingo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return _personService.GetAll();
        }
        
        [HttpGet(nameof(GetById) + "/{id}")]
        public ActionResult<Person> GetById(int id)
        {
            return _personService.FindById(id);
        }

        [HttpPost]
        public ActionResult<Person> Create(CreatePersonDto personDto)
        {
            return _personService.Create(new Person(personDto.Name));
        }
        
        
    }

    public class CreatePersonDto
    {
        public CreatePersonDto(string name)
        {
            Name = name;
        }

        public string Name { get; set;}
    }
}