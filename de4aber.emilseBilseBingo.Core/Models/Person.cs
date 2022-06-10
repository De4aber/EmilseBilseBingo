namespace de4aber.emilseBilseBingo.Core.Models
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public int Id { get; set; } = -1;
        public string Name { get; set; }
    }
}