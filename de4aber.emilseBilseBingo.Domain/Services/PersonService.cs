using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;

namespace de4aber.emilseBilseBingo.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> GetAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(int id)
        {
            return _personRepository.FindById(id);
        }
    }
}