namespace de4aber.emilseBilseBingo.DataAcess.Entities
{
    public class PersonEntity
    {
        public PersonEntity(string name)
        {
            Name = name;
        }

        public int Id { get; set; } = -1;
        
        public string Name { get; set; }
        
    }
}