namespace de4aber.emilseBilseBingo.Core.Models
{
    public class TileItem
    {
        public TileItem(string condition, Person ofPerson)
        {
            Condition = condition;
            OfPerson = ofPerson;
        }

        public int Id { get; set; } = -1;
        public string Condition { get; set; }
        public Person OfPerson { get; set; }
    }
}