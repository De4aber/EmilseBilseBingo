using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.DataAcess.Entities
{
    public class PersonEntity
    {
        public PersonEntity(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public Person ToPerson()
        {
            return new Person(Name)
            {
                Id = Id
            };
        }
    }
}