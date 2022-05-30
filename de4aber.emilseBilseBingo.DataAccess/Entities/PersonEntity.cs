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
    }
}