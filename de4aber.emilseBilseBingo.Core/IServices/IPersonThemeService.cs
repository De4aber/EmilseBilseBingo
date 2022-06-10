using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface IPersonThemeService
    {
        public List<PersonTheme> GetAll();

        public PersonTheme FindById(int id);
        
        public PersonTheme? FindByPersonId(int id);

        public PersonTheme Create(PersonTheme person);
    }
}