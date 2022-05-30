namespace de4aber.emilseBilseBingo.Core.Models
{
    public class TileItem
    {
        public TileItem(string condition, Person person)
        {
            Condition = condition;
            Person = person;
        }

        public int Id { get; set; }
        public string Condition { get; set; }
        public Person Person { get; set; }
    }
}