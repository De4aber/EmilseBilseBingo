using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface IPersonThemeService
    {
        public List<PersonTheme> GetAll();

        public Person FindById(int id);

        public Person Create(PersonTheme person);
    }
}