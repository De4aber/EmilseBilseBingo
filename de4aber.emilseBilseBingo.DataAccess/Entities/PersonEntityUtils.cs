using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.DataAcess.Entities
{
    public class PersonEntityUtils
    {
        public Person ToPerson(PersonEntity pe)
        {
            return new Person(pe.Name)
            {
                Id = pe.Id
            };
        }
    }
}