using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;

namespace de4aber.emilseBilseBingo.Domain.Services
{
    public class PersonThemeService: IPersonThemeService
    {
        private readonly IPersonThemeRepository _personThemeRepository;
        private readonly IPersonRepository _personRepository;

        public PersonThemeService(IPersonThemeRepository personThemeRepository, IPersonRepository personRepository)
        {
            _personThemeRepository = personThemeRepository;
            _personRepository = personRepository;
        }

        public List<PersonTheme> GetAll()
        {
            var list = _personThemeRepository.FindAll().Result;
            foreach (PersonTheme personTheme in list)
            {
                SetPerson(personTheme);
            }
            return list;
        }

        public PersonTheme FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PersonTheme Create(PersonTheme person)
        {
            throw new System.NotImplementedException();
        }
        
        private PersonTheme SetPerson(PersonTheme ti)
        {
            ti.TakenBy = _personRepository.FindById(ti.TakenByPersonId).Result;
            return ti;
        }
    }
}